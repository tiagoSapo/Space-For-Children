using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrabalhoPraticoPWeb1718.Models.ModelosBD
{
    public class PaiAutorizacao
    {
        public int PaiAutorizacaoId { get; set; }
        public string Nome { get; set; }
        public string Cidade { get; set; }
        public string Contacto { get; set; }
        public string Nacionalidade { get; set; }

        public int IdInstituicaoPreencher { get; set; }
    }
}