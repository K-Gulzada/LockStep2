using Autofac;
using Autofac.Integration.Mvc;
using LockStep2.Models;
using LockStep2.Repo.Interfaces;
using LockStep2.Repo.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System.Linq;
using System.Web.Mvc;

[assembly: OwinStartupAttribute(typeof(LockStep2.Startup))]
namespace LockStep2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<ApplicationDbContext>();
            builder.RegisterType<AuthorRepository>().As<IAuthorRepository>();
            builder.RegisterType<BookRepository>().As<IBookRepository>();
            builder.RegisterType<GenreRepository>().As<IGenreRepository>();
            builder.RegisterType<PaymentRepository>().As<IPaymentRepository>();
            builder.RegisterType<PriceRepository>().As<IPriceRepository>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            app.UseAutofacMiddleware(container);
            app.UseAutofacMvc();
        }

        private void SetupAuth()
        {
            var context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            (new string[] { "Admin", "Manager", "User" }).ToList().ForEach(p => CreateRole(roleManager, p));
           
            var user = new ApplicationUser { UserName = "stepAdmin@gmail.com", Email= "stepAdmin@gmail.com" };
            string userPwd = "A@Z200711";

            var checkUser = userManager.Create(user, userPwd);
            if (checkUser.Succeeded)
                userManager.AddToRole(user.Id, "Admin");
        }

        private class User
        {
            public string Name { get; set; }
            public string Pwd { get; set; }
            public string Role { get; set; }
        }

        private void CreateRole(RoleManager<IdentityRole> manager, string name)
        {
            if (!manager.RoleExists("Admin"))
                manager.Create(new IdentityRole { Name = "Admin" });
        }

        private void CreateUser(UserManager<ApplicationUser> manager, string name, string pwd, string role)
        {
            var user = new ApplicationUser { UserName = name, Email = name };

            var checkUser = manager.Create(user, pwd);
            if (checkUser.Succeeded)
                manager.AddToRole(user.Id, role);
        }
    }
}
