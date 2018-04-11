using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrabalhoPraticoPWeb1718.Models.ViewModels
{
    public class PaisAutorizacaoViewModel
    {
        [Required(ErrorMessage = "O {0} é obrigatório!")]
        [Remote("PaisNomeDisponivel", "Pais", ErrorMessage = "Esse nome já existe")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório!")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "O número de telefone tem 9 digitos!")]
        public string Contacto { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório!")]
        [Display(Name = "Naturalidade")]
        public string Nacionalidade { get; set; }

        [Display(Name = "Instituição")]
        public int IdInstituicaoPreencher { get; set; }
        public SelectList ListaInstituicoes { get; set; }

        [Display(Name = "Distrito")]
        public string Cidade { get; set; }
        public SelectList ListaCidades { get; set; }
    }
}