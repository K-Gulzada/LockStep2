using Autofac;
using Autofac.Integration.Mvc;
using LockStep2.Models;
using LockStep2.Repo.Interfaces;
using LockStep2.Repo.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System.Collections.Generic;
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
            new List<User>
            {
                new User {Name = "stepAdmin@gmail.com", Pwd = "qwerty123", Role = "Admin"},
                new User {Name = "manager@gmail.com", Pwd = "qwerty456", Role = "Manager"},
                new User {Name = "user@gmail.com", Pwd = "qwerty789", Role = "User"},
            }.ForEach(p => CreateUser(userManager, p));
        }
        private class User
        {
            public string Name { get; set; }
            public string Pwd { get; set; }
            public string Role { get; set; }
        }
        private void CreateRole(RoleManager<IdentityRole> manager, string name)
        {
            if (!manager.RoleExists(name))
                manager.Create(new IdentityRole { Name = name });
        }
        private void CreateUser(UserManager<ApplicationUser> manager, User usr)
        {
            var user = new ApplicationUser { UserName = usr.Name, Email = usr.Name };
            var checkUser = manager.Create(user, usr.Pwd);
            if (checkUser.Succeeded)
                manager.AddToRole(user.Id, usr.Role);
        }
    }
}
