using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrabalhoPraticoPWeb1718.Models.ModelosBD;

namespace TrabalhoPraticoPWeb1718.Models.ViewModels
{
    public class InstituicoesCidadesVM
    {
        public string Opcao { get; set; }
        public List<Instituicao> InstituicoesLista { get; set; }
    }
}