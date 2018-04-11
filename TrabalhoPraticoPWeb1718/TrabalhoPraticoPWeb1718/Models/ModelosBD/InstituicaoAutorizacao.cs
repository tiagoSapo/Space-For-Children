using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrabalhoPraticoPWeb1718.Models.ModelosBD
{
    public class InstituicaoAutorizacao
    {
        public int InstituicaoAutorizacaoId { get; set; }
        public string Nome { get; set; }
        public int NumeroProfessores { get; set; }
        public string Cidade { get; set; }
        public string Contacto { get; set; }
        public string Fax { get; set; }
        public string TipoInstituicao { get; set; }
        public string Servico { get; set; }
        public int Mensalidade { get; set; }
    }
}