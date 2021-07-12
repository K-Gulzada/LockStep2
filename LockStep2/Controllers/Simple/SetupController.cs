using LockStep2.Library.Domain.DAO.Finance;
using LockStep2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LockStep2.Controllers.Simple
{
    public class SetupController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SetupController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Setup
        public ActionResult Index()
        {
            ViewBag.IsEmptyAuthors = !_context.Authors.Any();
            ViewBag.IsEmptyGenres = !_context.Genres.Any();
            ViewBag.IsEmptyBooks = !_context.Books.Any();
            ViewBag.IsEmptyPrices = !_context.Prices.Any();
            return View();
        }
        [HttpPost]
        public ActionResult Index(string create_authors, string create_genres, string create_books, string create_prices)
        {
            if (!string.IsNullOrWhiteSpace(create_authors))
            {
                _context.Authors.Add(new Author { FullName = "Тестовый автор 1" });
                _context.Authors.Add(new Author { FullName = "Тестовый автор 2" });
                _context.Authors.Add(new Author { FullName = "Тестовый автор 3" });
            }
            if (!string.IsNullOrWhiteSpace(create_genres))
            {
                _context.Genres.Add(new Genre { Name = "Тестовый жанр 1" });
                _context.Genres.Add(new Genre { Name = "Тестовый жанр 2" });
                _context.Genres.Add(new Genre { Name = "Тестовый жанр 3" });
            }
            if (!string.IsNullOrWhiteSpace(create_books))
            {
                _context.Books.Add(new Book { Title = "Тестовая книга 1" });
                _context.Books.Add(new Book { Title = "Тестовая книга 2" });
                _context.Books.Add(new Book { Title = "Тестовая книга 3" });
            }
            var ok = SafeSave();
            if (ok != "ok")
                ViewBag.Error = ok;
            else
            {
                if (!string.IsNullOrWhiteSpace(create_prices))
                {
                    _context.Prices.Add(new Price { Value = "111", From = DateTime.Now, Book = new Book { Title = "Book with no \"To\"" } });
                    _context.Prices.Add(new Price { Value = "555", From = DateTime.Now, To = DateTime.Now, Book = _context.Books.Find(1) });

                }
                _context.SaveChanges();
            }
            ViewBag.IsEmptyAuthors = !_context.Authors.Any();
            ViewBag.IsEmptyGenres = !_context.Genres.Any();
            ViewBag.IsEmptyBooks = !_context.Books.Any();
            ViewBag.IsEmptyPrices = !_context.Prices.Any();
            return View();
        }
        private string SafeSave()
        {
            try
            {
                _context.SaveChanges();
                return "ok";
            }
            catch (Exception exception)
            {
                return exception.Message;
            }

        }
    }
}