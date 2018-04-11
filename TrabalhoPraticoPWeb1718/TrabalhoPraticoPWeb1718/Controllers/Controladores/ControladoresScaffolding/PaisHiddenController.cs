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
    public class PaisHiddenController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PaisHidden
        public ActionResult Index()
        {
            return View(db.Pais.ToList());
        }

        // GET: PaisHidden/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pai pai = db.Pais.Find(id);
            if (pai == null)
            {
                return HttpNotFound();
            }
            return View(pai);
        }

        // GET: PaisHidden/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaisHidden/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PaiId,Nome,Cidade,Contacto,Nacionalidade")] Pai pai)
        {
            if (ModelState.IsValid)
            {
                db.Pais.Add(pai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pai);
        }

        // GET: PaisHidden/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pai pai = db.Pais.Find(id);
            if (pai == null)
            {
                return HttpNotFound();
            }
            return View(pai);
        }

        // POST: PaisHidden/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PaiId,Nome,Cidade,Contacto,Nacionalidade")] Pai pai)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pai);
        }

        // GET: PaisHidden/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pai pai = db.Pais.Find(id);
            if (pai == null)
            {
                return HttpNotFound();
            }
            return View(pai);
        }

        // POST: PaisHidden/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pai pai = db.Pais.Find(id);
            db.Pais.Remove(pai);
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
