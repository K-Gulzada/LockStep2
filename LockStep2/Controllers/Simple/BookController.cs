using LockStep2.Models;
using LockStep2.Repo.Interfaces;
using LockStep2.Repo.Repositories;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LockStep2.Controllers.Simple
{
    public class BookController : Controller
    {
        private BookRepository db = new BookRepository(new ApplicationDbContext());

        // GET: Books
        public async Task<ActionResult> Index(/*int? page*/)
        {
            var books = await db.Get();

            int pageSize = 20;
            int pageNumber = page ?? 1;

            return View(books.ToPagedList(pageNumber, pageSize));
        }


        // GET: Books/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = await db.GetById(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [HttpPost, ActionName("PartialView")]
        public async Task<ActionResult> PartialDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = await db.GetById(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return PartialView(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Insert(book);

                return RedirectToAction("Index");
            }

            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = await db.GetById(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name")] Book book)
        {
            if (ModelState.IsValid)
            {
                await db.Update(book);

                return RedirectToAction("Index");
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = await db.GetById(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Book book = await db.GetById(id);
            await db.Delete(book);

            return RedirectToAction("Index");
        }
    }
}