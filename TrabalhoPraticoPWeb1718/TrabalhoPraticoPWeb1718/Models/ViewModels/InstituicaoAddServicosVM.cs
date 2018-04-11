using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrabalhoPraticoPWeb1718.Models.ViewModels
{
    public class InstituicaoAddServicosVM
    {
        public string OpcaoServicos { get; set; }
        public SelectList ListaServicos { get; set; }
    }
}