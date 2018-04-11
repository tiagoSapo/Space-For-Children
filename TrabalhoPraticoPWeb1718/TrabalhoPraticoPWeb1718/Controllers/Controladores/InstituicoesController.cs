using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrabalhoPraticoPWeb1718.Models;
using TrabalhoPraticoPWeb1718.Models.ModelosBD;
using TrabalhoPraticoPWeb1718.Models.Perfis;
using TrabalhoPraticoPWeb1718.Models.ViewModels;

namespace TrabalhoPraticoPWeb1718.Controllers.Controladores
{
    [Authorize(Roles = Perfis.Admin + "," + Perfis.Instituicao)]
    public class InstituicoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private const string INSTITUICAO_UTILIZADOR = "INSTITUICAO_UTILIZADOR";

        public ActionResult Index()
        {
            ViewBag.Utilizador = Session[INSTITUICAO_UTILIZADOR];
            return View();
        }
        public ActionResult ListaAlunos()
        {
            string nomeInstituicao = Session[INSTITUICAO_UTILIZADOR] as string;
            ViewBag.Instituicao = nomeInstituicao;
            if (nomeInstituicao == null)
                throw new Exception("INSTITUICOES - Nenhuma instituicao está activada!");
            Instituicao i = (from e in db.Instituicoes where e.Nome == nomeInstituicao select e).ToList()[0];
            return View(i.Criancas.ToList());
        }


        public ActionResult Create()
        {
            return View(AdicionaListas(new InstituicoesAutorizacaoViewModel()));
        }
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "listaDistritos, listaEnsinos, listaTipoInstituicoes")]InstituicoesAutorizacaoViewModel iavm)
        {
            if (ModelState.IsValid)
            {
                var instituicao = new InstituicaoAutorizacao
                {
                    Nome = iavm.Nome,
                    Contacto = iavm.Contacto,
                    Fax = iavm.Fax,
                    NumeroProfessores = iavm.NumeroProfessores,
                    TipoInstituicao = iavm.TipoInstituicao,
                    Cidade = iavm.Cidade,
                    Mensalidade = iavm.Mensalidade
                };
                int id = Int32.Parse(iavm.Servico);
                Ensino e = db.Ensinos.Find(id);
                if (e == null)
                    throw new Exception("Este tipo de Serviço não existe!");
                instituicao.Servico = e.EnsinoId.ToString();

                db.InstituicoesAutorizacao.Add(instituicao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(iavm);
        }
        [NonAction]
        public InstituicoesAutorizacaoViewModel AdicionaListas(InstituicoesAutorizacaoViewModel iavm)
        {
            List<string> distritos = Distritos.GetListaDistritos();
            List<SelectListItem> listaDistritos = new List<SelectListItem>();
            List<SelectListItem> listaEnsinos = new List<SelectListItem>();
            List<SelectListItem> listaTipoInstituicoes = new List<SelectListItem>()
            {
                new SelectListItem { Value = "Privada", Text = "Privada"},
                new SelectListItem { Value = "Pública", Text = "Pública"},
                new SelectListItem { Value = "IPSS", Text = "IPSS"}
            };

            foreach (string s in distritos)
                listaDistritos.Add(new SelectListItem { Value = s, Text = s });
            foreach (Ensino s in db.Ensinos.ToList())
                listaEnsinos.Add(new SelectListItem { Value = s.EnsinoId.ToString(), Text = s.Nome });

            SelectList s1 = new SelectList(listaDistritos, "Value", "Text");
            SelectList s2 = new SelectList(listaEnsinos, "Value", "Text");
            SelectList s3 = new SelectList(listaTipoInstituicoes, "Value", "Text");

            iavm.ListaCidades = s1;
            iavm.ListaEnsinos = s2;
            iavm.ListaTipoInstituicoes = s3;

            return iavm;
        }


        public ActionResult List()
        {
            return View(db.Instituicoes.ToList());
        }

        public ActionResult Pais()
        {
            return View(db.PaisAutorizacao.ToList());
        }
        public ActionResult AutorizaPai(int id)
        {
            var pa = db.PaisAutorizacao.Find(id);
            var p = new Pai
            {
                Cidade = pa.Cidade,
                Nome = pa.Nome,
                Contacto = pa.Contacto,
                Nacionalidade = pa.Nacionalidade
            };

            db.PaisAutorizacao.Remove(pa);
            db.Pais.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Avaliacao()
        {
            string nomeInstituicao = Session[INSTITUICAO_UTILIZADOR] as string;
            ViewBag.Instituicao = nomeInstituicao;
            if (nomeInstituicao == null)
                throw new Exception("INSTITUICOES - Nenhuma instituicao está activada!");
            Instituicao i = (from e in db.Instituicoes where e.Nome == nomeInstituicao select e).ToList()[0];
            return View(i.Criancas.ToList());
        }

        public ActionResult AddServicos()
        {
            string nomeInstituicao = Session[INSTITUICAO_UTILIZADOR] as string;
            ViewBag.Instituicao = nomeInstituicao;
            if (nomeInstituicao == null)
                throw new Exception("INSTITUICOES - Nenhuma instituicao está activada!");
            Instituicao i = (from e in db.Instituicoes where e.Nome == nomeInstituicao select e).ToList()[0];

            List<SelectListItem> listaServicos = new List<SelectListItem>();
            foreach (var a in db.Ensinos)
                listaServicos.Add(new SelectListItem { Value = a.EnsinoId.ToString(), Text = a.Nome });

            SelectList s = new SelectList(listaServicos, "Value", "Text");
            var serv = new InstituicaoAddServicosVM { ListaServicos = s };

            return View(serv);
        }
        [HttpPost]
        public ActionResult AddServicos([Bind(Exclude = "ListaServicos")] InstituicaoAddServicosVM modelo)
        {
            string nomeInstituicao = Session[INSTITUICAO_UTILIZADOR] as string;
            ViewBag.Instituicao = nomeInstituicao;
            if (nomeInstituicao == null)
                throw new Exception("INSTITUICOES - Nenhuma instituicao está activada!");
            Instituicao i = (from e in db.Instituicoes where e.Nome == nomeInstituicao select e).ToList()[0];

            if (ModelState.IsValid)
            {
                int id = Int32.Parse(modelo.OpcaoServicos);
                Ensino e = db.Ensinos.Find(id);
                if (!i.Ensinos.Contains(e))
                {
                    e.Instituicoes.Add(i);
                    i.Ensinos.Add(e);
                    db.SaveChanges();
                }
                return RedirectToAction("ListaServicos");
            }
            List<SelectListItem> listaServicos = new List<SelectListItem>();
            foreach (var a in db.Ensinos)
                listaServicos.Add(new SelectListItem { Value = a.EnsinoId.ToString(), Text = a.Nome });

            SelectList s = new SelectList(listaServicos, "Value", "Text");
            return View(modelo);
        }


        public ActionResult ListaServicos()
        {
            string nomeInstituicao = Session[INSTITUICAO_UTILIZADOR] as string;
            ViewBag.Instituicao = nomeInstituicao;
            if (nomeInstituicao == null)
                throw new Exception("INSTITUICOES - Nenhuma instituicao está activada!");
            Instituicao i = (from e in db.Instituicoes where e.Nome == nomeInstituicao select e).ToList()[0];

            return View(i.Ensinos.ToList());
        }

        public ActionResult Pedidos()
        {
            var instituicaoNome = Session[INSTITUICAO_UTILIZADOR] as string;
            Instituicao i = (from e in db.Instituicoes where e.Nome == instituicaoNome select e).ToList()[0];
            if (i == null)
                throw new Exception("Pedidos");

            return View((from s in db.Pedidos where s.InstituicaoId == i.InstituicaoId select s).ToList());
        }
        public ActionResult ResponderPedido(int id)
        {
            return View(new PedidosInstituicao { IdPedido = id });
        }
        [HttpPost]
        public ActionResult ResponderPedido(PedidosInstituicao pc)
        {
            if (ModelState.IsValid)
            {
                Pedidos p = db.Pedidos.Find(pc.IdPedido);
                p.MsgInstituicao = pc.Mensagem;
                db.SaveChanges();
                return RedirectToAction("Pedidos");
            }
            return View(pc);
        }


        public ActionResult Entrar(int id)
        {
            Instituicao i = db.Instituicoes.Find(id);
            if (i == null)
                throw new Exception("INSTITUICOES - Erro ao entrar como esta Instituicao");
            Session[INSTITUICAO_UTILIZADOR] = i.Nome;
            return RedirectToAction("Index");
        }
        public ActionResult Sair()
        {
            Session[INSTITUICAO_UTILIZADOR] = null;
            return RedirectToAction("Index");
        }

        public JsonResult ValidarInstituicaoNome(string Nome)
        {
            bool existe = false;
            foreach (Instituicao i in db.Instituicoes)
            {
                if (i.Nome == Nome)
                {
                    existe = true;
                    break;
                }
            }
            return Json(!existe, JsonRequestBehavior.AllowGet);
        }
    }
}