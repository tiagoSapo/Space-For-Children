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
    public class InstituicoesHiddenController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: InstituicoesHidden
        public ActionResult Index()
        {
            return View(db.Instituicoes.ToList());
        }

        // GET: InstituicoesHidden/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instituicao instituicao = db.Instituicoes.Find(id);
            if (instituicao == null)
            {
                return HttpNotFound();
            }
            return View(instituicao);
        }

        // GET: InstituicoesHidden/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InstituicoesHidden/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InstituicaoId,Nome,NumeroProfessores,Cidade,Contacto,Fax,TipoInstituicao, Mensalidade")] Instituicao instituicao)
        {
            if (ModelState.IsValid)
            {
                db.Instituicoes.Add(instituicao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(instituicao);
        }

        // GET: InstituicoesHidden/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instituicao instituicao = db.Instituicoes.Find(id);
            if (instituicao == null)
            {
                return HttpNotFound();
            }
            return View(instituicao);
        }

        // POST: InstituicoesHidden/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InstituicaoId,Nome,NumeroProfessores,Cidade,Contacto,Fax,TipoInstituicao, Mensalidade")] Instituicao instituicao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(instituicao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(instituicao);
        }

        // GET: InstituicoesHidden/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instituicao instituicao = db.Instituicoes.Find(id);
            if (instituicao == null)
            {
                return HttpNotFound();
            }
            return View(instituicao);
        }

        // POST: InstituicoesHidden/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Instituicao instituicao = db.Instituicoes.Find(id);
            db.Instituicoes.Remove(instituicao);
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
