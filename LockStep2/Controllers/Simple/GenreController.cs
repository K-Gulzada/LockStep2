using LockStep2.Models;
using LockStep2.Repo.Interfaces;
using LockStep2.Repo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LockStep2.Controllers.Simple
{
    public class GenreController : Controller
    {
        private GenreRepository db = new GenreRepository(new ApplicationDbContext());

        // GET: Genres
        public async Task<ActionResult> Index()
        {
            return View(await db.Get());
        }

        // GET: Genres/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genre genre = await db.GetById(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        // GET: Genres/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Genres/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Genre genre)
        {
            if (ModelState.IsValid)
            {
                db.Insert(genre);

                return RedirectToAction("Index");
            }

            return View(genre);
        }

        // GET: Genres/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genre genre = await db.GetById(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        // POST: Genres/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name")] Genre genre)
        {
            if (ModelState.IsValid)
            {

                await db.Update(genre);
                return RedirectToAction("Index");
            }
            return View(genre);
        }

        // GET: Genres/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genre genre = await db.GetById(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        // POST: Genres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Genre genre = await db.GetById(id);
            await db.Delete(genre);

            return RedirectToAction("Index");
        }
    }
}