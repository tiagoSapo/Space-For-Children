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
    public class CriancasHiddenController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CriancasHidden
        public ActionResult Index()
        {
            return View(db.Criancas.ToList());
        }

        // GET: CriancasHidden/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crianca crianca = db.Criancas.Find(id);
            if (crianca == null)
            {
                return HttpNotFound();
            }
            return View(crianca);
        }

        // GET: CriancasHidden/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CriancasHidden/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CriancaId,Nome,Genero,DataNascimento,Avaliacao,DataContrato")] Crianca crianca)
        {
            if (ModelState.IsValid)
            {
                db.Criancas.Add(crianca);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(crianca);
        }

        // GET: CriancasHidden/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crianca crianca = db.Criancas.Find(id);
            if (crianca == null)
            {
                return HttpNotFound();
            }
            return View(crianca);
        }

        // POST: CriancasHidden/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CriancaId,Nome,Genero,DataNascimento,Avaliacao,DataContrato")] Crianca crianca)
        {
            if (ModelState.IsValid)
            {
                db.Entry(crianca).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(crianca);
        }

        // GET: CriancasHidden/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crianca crianca = db.Criancas.Find(id);
            if (crianca == null)
            {
                return HttpNotFound();
            }
            return View(crianca);
        }

        // POST: CriancasHidden/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Crianca crianca = db.Criancas.Find(id);
            db.Criancas.Remove(crianca);
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
