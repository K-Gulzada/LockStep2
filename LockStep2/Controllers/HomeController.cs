using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LockStep2.Repo.Repositories;
using LockStep2.Models;
using System.Threading.Tasks;

namespace LockStep2.Controllers
{
    public class HomeController : Controller
    {
        private BookRepository db = new BookRepository(new ApplicationDbContext());
        private GenreRepository db2 = new GenreRepository(new ApplicationDbContext());
        private AuthorRepository db3 = new AuthorRepository(new ApplicationDbContext());
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            /*var bookTitleLines = System.IO.File.ReadAllLines(@"C:\\Users\\КахарГ.NEW\\source\\repos\\LockStep2\\LockStep2\\files\\books.csv");
            foreach (var line in bookTitleLines)
            {
                try
                {
                    db.Insert(new Book { Title = line });
                }
                catch(Exception exception)
                {
                    var t = exception;
                }
            }*/

           /* var genreNamelines = System.IO.File.ReadAllLines(@"C:\\Users\\КахарГ.NEW\\source\\repos\\LockStep2\\LockStep2\\files\\genres.csv");
            foreach (var line in genreNamelines)
            {
                db2.Insert(new Genre { Name = line });
            }

            var authorFullNamelines = System.IO.File.ReadAllLines(@"C:\\Users\\КахарГ.NEW\\source\\repos\\LockStep2\\LockStep2\\files\\authors.csv");
            foreach (var line in authorFullNamelines)
            {
                db3.Insert(new Author { FullName = line });
            }*/
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}