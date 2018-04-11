using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrabalhoPraticoPWeb1718.Models.ViewModels
{
    public class PedidosCliente
    {
        [Display(Name = "Instituição")]
        public string OpcaoInstituicao { get; set; }
        public SelectList ListaIntituicoes { get; set; }

        [StringLength(100, MinimumLength = 5, ErrorMessage = "A mensagem tem que ter entre 5 a 100 caracteres")]
        public string Mensagem { get; set; }
    }
}