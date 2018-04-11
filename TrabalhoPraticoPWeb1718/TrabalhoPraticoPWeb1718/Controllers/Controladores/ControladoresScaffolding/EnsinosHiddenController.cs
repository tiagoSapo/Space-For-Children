using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrabalhoPraticoPWeb1718.Models;
using TrabalhoPraticoPWeb1718.Models.ModelosBD;

namespace TrabalhoPraticoPWeb1718.Controllers.Controladores.ControladoresScaffolding
{
    public class EnsinosHiddenController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EnsinosHidden
        public ActionResult Index()
        {
            return View(db.Ensinos.ToList());
        }

        // GET: EnsinosHidden/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ensino ensino = db.Ensinos.Find(id);
            if (ensino == null)
            {
                return HttpNotFound();
            }
            return View(ensino);
        }

        // GET: EnsinosHidden/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EnsinosHidden/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EnsinoId,Nome")] Ensino ensino)
        {
            if (ModelState.IsValid)
            {
                db.Ensinos.Add(ensino);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ensino);
        }

        // GET: EnsinosHidden/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ensino ensino = db.Ensinos.Find(id);
            if (ensino == null)
            {
                return HttpNotFound();
            }
            return View(ensino);
        }

        // POST: EnsinosHidden/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EnsinoId,Nome")] Ensino ensino)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ensino).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ensino);
        }

        // GET: EnsinosHidden/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ensino ensino = db.Ensinos.Find(id);
            if (ensino == null)
            {
                return HttpNotFound();
            }
            return View(ensino);
        }

        // POST: EnsinosHidden/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ensino ensino = db.Ensinos.Find(id);
            db.Ensinos.Remove(ensino);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
