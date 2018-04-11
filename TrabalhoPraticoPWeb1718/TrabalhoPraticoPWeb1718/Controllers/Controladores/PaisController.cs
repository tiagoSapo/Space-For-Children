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
    [Authorize(Roles = Perfis.Admin + "," + Perfis.Pai)]
    public class PaisController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private const string UTILIZADOR = "UTILIZADOR";

        public ActionResult Index()
        {
            ViewBag.Utilizador = Session[UTILIZADOR];
            return View();
        }

        public ActionResult Create()
        {
            return View(GetListaInstituicoes(new PaisAutorizacaoViewModel()));
        }
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "ListaInstituicoes, ListaCidades")]PaisAutorizacaoViewModel pavm)
        {
            if (ModelState.IsValid)
            {
                PaiAutorizacao p = new PaiAutorizacao
                {
                    Nome = pavm.Nome,
                    Nacionalidade = pavm.Nacionalidade,
                    Contacto = pavm.Contacto,
                };
                p.IdInstituicaoPreencher = pavm.IdInstituicaoPreencher;
                p.Cidade = pavm.Cidade;

                db.PaisAutorizacao.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(GetListaInstituicoes(new PaisAutorizacaoViewModel()));
        }
        [NonAction]
        public PaisAutorizacaoViewModel GetListaInstituicoes(PaisAutorizacaoViewModel pavm)
        {
            List<SelectListItem> lista = new List<SelectListItem>();
            List<SelectListItem> cidades = new List<SelectListItem>();

            foreach (Instituicao ss in db.Instituicoes)
                lista.Add(new SelectListItem { Value = ss.InstituicaoId.ToString(), Text = ss.Nome });
            foreach (string ss in Distritos.GetListaDistritos())
                cidades.Add(new SelectListItem { Value = ss, Text = ss });

            SelectList s = new SelectList(lista, "Value", "Text");
            SelectList d = new SelectList(cidades, "Value", "Text");
            pavm.ListaInstituicoes = s;
            pavm.ListaCidades = d;
            return pavm;
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
        public ActionResult Entrar(int id)
        {
            Pai p = db.Pais.Find(id);
            if (p == null)
                throw new Exception("PAIS - Erro ao entrar como este pai");
            Session[UTILIZADOR] = p.Nome;
            return RedirectToAction("Index");
        }
        public ActionResult Sair()
        {
            Session[UTILIZADOR] = null;
            return RedirectToAction("Index");
        }


        public ActionResult ListaFilhos()
        {
            string s = (Session[UTILIZADOR] as string);
            Pai pai = (from i in db.Pais where i.Nome == s select i).ToList()[0];
            return View(pai.Criancas.ToList());
        }
        public JsonResult ObtemEnsinos(string ID)
        {
            if (ID == null)
                throw new Exception("Id = null");
            int id = Int32.Parse(ID);
            Instituicao inst = (from i in db.Instituicoes where i.InstituicaoId == id select i).ToList()[0];
            if (inst == null)
                throw new Exception("Instituicao nao existe");
            var t = (from e in db.Ensinos
                    where e.Instituicoes.Any(i => i.InstituicaoId == inst.InstituicaoId)
                    select new { e.EnsinoId, e.Nome}).ToList();
            return Json(t, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CreateFilho()
        {
            ViewBag.Utilizador = Session[UTILIZADOR] as string;

            List<SelectListItem> l = new List<SelectListItem>();
            ViewBag.Ensinos = new SelectList(l, "Value", "Text");
            return View(AdicionaListas(new CriancasPaisInsituicaoEnsinoVM() { DataNascimento = DateTime.Now }));
        }
        [HttpPost]
        public ActionResult CreateFilho([Bind(Exclude = "ListaPais, ListaInstituicoes, Avaliacao, DataContrato")]CriancasPaisInsituicaoEnsinoVM cpievm)
        {
            if (ModelState.IsValid)
            {
                var c = new Crianca
                {
                    Nome = cpievm.Nome,
                    Avaliacao = -1,
                    DataContrato = DateTime.Now,
                    DataNascimento = cpievm.DataNascimento,
                    Genero = cpievm.Genero,
                };

                string utilizador = Session[UTILIZADOR] as string;
                if (utilizador == null)
                    throw new Exception("PAIS - Pai não tem a conta activada");

                var idI = Int32.Parse(cpievm.Instituicao);
                var idE = Int32.Parse(cpievm.OpcaoEnsino);
                Pai pp = (from procura in db.Pais where procura.Nome == utilizador select procura).ToList()[0];
                Instituicao ii = db.Instituicoes.Find(idI);
                Ensino e = (from ensinos in db.Ensinos where ensinos.EnsinoId == idE select ensinos).ToList()[0];
                if (pp == null || ii == null || e == null)
                    throw new Exception("PAIS - Pai ou Instituicao nao existem!");
                //var e = ii.Ensinos.ToList()[0];

                pp.Criancas.Add(c);
                ii.Criancas.Add(c);
                e.Criancas.Add(c);

                c.Pai = pp;
                c.Instituicao = ii;
                c.Ensino = e;

                db.Criancas.Add(c);
                db.SaveChanges();

                return RedirectToAction("ListaFilhos");
            }
            List<SelectListItem> l = new List<SelectListItem>();
            ViewBag.Ensinos = new SelectList(l, "Value", "Text");
            return View(AdicionaListas(cpievm));
        }
        [NonAction]
        public CriancasPaisInsituicaoEnsinoVM AdicionaListas(CriancasPaisInsituicaoEnsinoVM c)
        {
            List<SelectListItem> instituicoes = new List<SelectListItem>();
            foreach (Instituicao i in db.Instituicoes)
                instituicoes.Add(new SelectListItem { Value = i.InstituicaoId.ToString(), Text = i.Nome });

            SelectList si = new SelectList(instituicoes, "Value", "Text");

            c.ListaInstituicoes = si;
            return c;
        }

        public ActionResult AvaliarInstituicao(int id)
        {
            var f = new AvaliacaoVM { Filho = id.ToString() };
            return View(f);
        }
        [HttpPost]
        public ActionResult AvaliarInstituicao(AvaliacaoVM a)
        {
            if (ModelState.IsValid)
            {
                if (a.Avaliacao >= 0 && a.Avaliacao <= 20)
                {
                    int idd = Int32.Parse(a.Filho);
                    Crianca c = db.Criancas.Find(idd);
                    if (c == null)
                        throw new Exception("PAIS - Alguem apagou este filho!");
                    c.Avaliacao = a.Avaliacao;
                    db.SaveChanges();
                    return RedirectToAction("ListaFilhos");
                }
            }
            return View(a);
        }
        public ActionResult Pedidos()
        {
            string paiNome = Session[UTILIZADOR] as string;
            Pai p = (from i in db.Pais where i.Nome == paiNome select i).ToList()[0];

            if (p == null)
                throw new Exception("PAIS - este pai não existe");

            List<Pedidos> pedidos = (from s in db.Pedidos where s.PaiId == p.PaiId select s).ToList();
            return View(pedidos);
        }
        public ActionResult FazerPedido()
        {
            List<SelectListItem> l = new List<SelectListItem>();
            foreach (var i in db.Instituicoes)
                l.Add(new SelectListItem { Value = i.InstituicaoId.ToString(), Text = i.Nome });

            SelectList s = new SelectList(l, "Value", "Text");
            return View(new PedidosCliente { ListaIntituicoes = s });
        }
        [HttpPost]
        public ActionResult FazerPedido([Bind(Exclude = "ListaInstituicoes")]PedidosCliente pc)
        {
            if (ModelState.IsValid)
            {
                string paiNome = Session[UTILIZADOR] as string;
                Pai p = (from i in db.Pais where i.Nome == paiNome select i).ToList()[0];

                if (p == null)
                    throw new Exception("PAIS - este pai não existe");

                var idInst = Int32.Parse(pc.OpcaoInstituicao);
                db.Pedidos.Add(new Pedidos { MsgPai = pc.Mensagem, InstituicaoId = idInst, PaiId = p.PaiId, MsgInstituicao = "" });
                db.SaveChanges();

                return RedirectToAction("Pedidos");
            }
            List<SelectListItem> l = new List<SelectListItem>();
            foreach (var i in db.Instituicoes)
                l.Add(new SelectListItem { Value = i.InstituicaoId.ToString(), Text = i.Nome });

            SelectList s = new SelectList(l, "Value", "Text");
            pc.ListaIntituicoes = s;
            return View(pc);
        }


        public JsonResult CriancaNomeDisponivel(string Nome)
        {
            bool existe = false;
            foreach (Crianca c in db.Criancas)
            {
                if (c.Nome == Nome)
                {
                    existe = true;
                    break;
                }
            }
            return Json(!existe, JsonRequestBehavior.AllowGet);
        }
        public JsonResult PaisNomeDisponivel(string Nome)
        {
            bool existe = false;
            foreach (Pai c in db.Pais)
            {
                if (c.Nome == Nome)
                {
                    existe = true;
                    return Json(!existe, JsonRequestBehavior.AllowGet);
                }
            }
            foreach (PaiAutorizacao c in db.PaisAutorizacao)
            {
                if (c.Nome == Nome)
                {
                    existe = true;
                    break;
                }
            }
            return Json(!existe, JsonRequestBehavior.AllowGet);
        }
    }
}