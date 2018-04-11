using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrabalhoPraticoPWeb1718.Models.ViewModels
{
    public class PedidosInstituicao
    {
        public int IdPedido { get; set; }
        [StringLength(100, MinimumLength = 10, ErrorMessage = "A mensagem deve ter entre 10 a 100 caracteres")]
        public string Mensagem { get; set; }
    }
}