using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrabalhoPraticoPWeb1718.Models.ViewModels
{
    public class AvaliacaoVM
    {
        public string Filho { get; set; }

        [Required(ErrorMessage = "A {0} é obrigatória!")]
        [Display(Name = "Avaliação da Instituição (0 a 20 Valores)")]
        [Range(0, 20, ErrorMessage = "A {0} não é válida")]
        public int Avaliacao { get; set; }
    }
}