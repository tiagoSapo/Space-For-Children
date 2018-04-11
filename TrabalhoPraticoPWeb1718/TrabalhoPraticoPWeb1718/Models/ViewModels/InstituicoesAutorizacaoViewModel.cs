using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrabalhoPraticoPWeb1718.Models.ViewModels
{
    public class InstituicoesAutorizacaoViewModel
    {
        [Required(ErrorMessage = "O {0} é obrigatório")]
        [Display(Name = "Nome da instituição")]
        [Remote("ValidarInstituicaoNome", "Instituicoes", ErrorMessage = "Já existe uma instituição com esse nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório")]
        [Display(Name = "Número de docentes da instituição")]
        [Range(1, 500, ErrorMessage = "O {0} deverá estar entre 1 e 500")]
        public int NumeroProfessores { get; set; }

        [Display(Name = "Distrito")]
        public string Cidade { get; set; }
        public SelectList ListaCidades { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório")]
        [Display(Name = "Número de telefone")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "O número de telefone tem 9 dígitos")]
        public string Contacto { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "O número de fax tem 9 dígitos")]
        public string Fax { get; set; }

        [Display(Name = "Tipo de instituição")]
        public string TipoInstituicao { get; set; }
        public SelectList ListaTipoInstituicoes { get; set; }

        [Display(Name = "Serviço inicial")]
        public string Servico { get; set; }
        public SelectList ListaEnsinos { get; set; }

        [Required(ErrorMessage = "A {0} é obrigatória")]
        [Display(Name = "Mensalidade (Euros)")]
        [Range(10, 1000, ErrorMessage = "A mensalidade deverá estar entre 10 e 1000 euros")]
        public int Mensalidade { get; set; }
    }
}