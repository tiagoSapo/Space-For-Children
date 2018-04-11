using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrabalhoPraticoPWeb1718.Models.Perfis;

namespace TrabalhoPraticoPWeb1718.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.IsInRole(Perfis.Admin))
                return Redirect("Admin");
            else if (User.IsInRole(Perfis.Instituicao))
                return Redirect("Instituicoes");
            else if (User.IsInRole(Perfis.Pai))
                return Redirect("Pais");
            else
                return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Autor = "Autor: A21240385 - Tiago Simões";
            return View();
        }
    }
}