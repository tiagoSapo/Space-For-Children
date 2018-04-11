using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrabalhoPraticoPWeb1718.Models.ModelosBD;

namespace TrabalhoPraticoPWeb1718.Models.ViewModels
{
    public class CriancasPaisInsituicaoEnsinoVM
    {
        [Required(ErrorMessage = "O {0} é obrigatório!")]
        [Remote("CriancaNomeDisponivel", "Pais", ErrorMessage = "Já existe uma criança com esse nome no sistema")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório!")]
        [Display(Name = "Género")]
        public Genero Genero { get; set; }

        [Required(ErrorMessage = "A {0} é obrigatória!")]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        public int? Avaliacao { get; set; }
        public DateTime? DataContrato { get; set; }

        [Display(Name = "Instituição")]
        public string Instituicao { get; set; }
        public SelectList ListaInstituicoes { get; set; }

        [Display(Name = "Opção de Ensino")]
        public string OpcaoEnsino { get; set; }
    }
}