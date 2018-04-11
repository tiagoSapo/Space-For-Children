using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrabalhoPraticoPWeb1718.Models;
using TrabalhoPraticoPWeb1718.Models.ModelosBD;
using TrabalhoPraticoPWeb1718.Models.Perfis;

namespace TrabalhoPraticoPWeb1718.Controllers.Controladores
{
    [Authorize(Roles = Perfis.Admin)]
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Instituicoes()
        {
            return View(db.InstituicoesAutorizacao.ToList());
        }
        public ActionResult AutorizaInstituicao(int id)
        {
            var i = db.InstituicoesAutorizacao.Find(id);
            var nova_instituicao = new Instituicao {
                Cidade = i.Cidade,
                Contacto = i.Contacto,
                Fax = i.Fax,
                Nome = i.Nome,
                NumeroProfessores = i.NumeroProfessores,
                TipoInstituicao = i.TipoInstituicao,
                Mensalidade = i.Mensalidade,
                Criancas = new HashSet<Crianca>(),
                Ensinos = new HashSet<Ensino>()
            };

            int id2 = Int32.Parse(i.Servico);
            Ensino e = db.Ensinos.Find(id2);
            if (e == null)
                throw new Exception("ADMIN - Este tipo de Serviço não existe!");

            nova_instituicao.Ensinos.Add(e);
            e.Instituicoes.Add(nova_instituicao);

            db.Instituicoes.Add(nova_instituicao);
            db.InstituicoesAutorizacao.Remove(i);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
