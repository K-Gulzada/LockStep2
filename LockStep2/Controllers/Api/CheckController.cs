using LockStep2.Library.Domain.NewFolder1;
using LockStep2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace LockStep2.Controllers
{
    public class CheckController : ApiController
    {
        // GET: Check
        private ApplicationDbContext db = new ApplicationDbContext();
        public async Task<IHttpActionResult> Get(int id)
        {
            if (id <= 0)
                return BadRequest("Входящий параметр не определен");

            var book = await SafeGetBook(id);

            if (book is null)
                return NotFound();

            var price = await SafeGetPrice(id);

            if (price is null)
                return Ok(new { id = id, product = book.Title, price = price.Value });

            return null;
        }

        private async Task<Book> SafeGetBook(int id)
        {
            try
            {
                return await db.Books.FindAsync(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private async Task<Price> SafeGetPrice(int bookId)
        {
            try
            {
                return await db.Prices.FirstOrDefaultAsync(p => p.Book.Id == bookId && p.To == null);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}