using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrabalhoPraticoPWeb1718.Models.ModelosBD
{
    public class Instituicao
    {
        public Instituicao()
        {
            Criancas = new HashSet<Crianca>();
            Ensinos = new HashSet<Ensino>();
        }
        public int InstituicaoId { get; set; }
        public string Nome { get; set; }
        public int NumeroProfessores { get; set; }
        public string Cidade { get; set; }
        public string Contacto { get; set; }
        public string Fax { get; set; }
        public string TipoInstituicao { get; set; }
        public int Mensalidade { get; set; }

        public virtual ICollection<Crianca> Criancas { get; set; }
        public virtual ICollection<Ensino> Ensinos { get; set; }
    }
}