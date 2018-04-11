using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrabalhoPraticoPWeb1718.Models;
using TrabalhoPraticoPWeb1718.Models.ModelosBD;
using TrabalhoPraticoPWeb1718.Models.ViewModels;

namespace TrabalhoPraticoPWeb1718.Controllers.Controladores
{
    
    public class GeralController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListaInstituicoes(InstituicoesCidadesVM c)
        {
            if (ViewBag.LISTA == null)
            {
                List<SelectListItem> distritos = new List<SelectListItem>();
                distritos.Add(new SelectListItem { Value = (-1).ToString(), Text = "Todas as Cidades" });
                foreach (var i in Models.Perfis.Distritos.GetListaDistritos())
                    distritos.Add(new SelectListItem { Value = i, Text = i });              
                SelectList s = new SelectList(distritos, "Value", "Text");
                ViewBag.LISTA = s;
            }

            if (Request.IsAjaxRequest())
            {
                if (c.Opcao == "-1")
                    return PartialView("_Listar", db.Instituicoes.ToList());
                var cc = (from e in db.Instituicoes where e.Cidade == c.Opcao select e).ToList();
                return PartialView("_Listar", cc);
            }
            return View(new InstituicoesCidadesVM { InstituicoesLista = db.Instituicoes.ToList() });
        }
        public ActionResult ListaPais()
        {
            return View(db.Pais.ToList());
        }
    }
}
