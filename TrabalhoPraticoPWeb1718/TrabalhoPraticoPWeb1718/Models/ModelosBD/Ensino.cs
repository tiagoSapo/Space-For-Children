using System.Collections.Generic;

namespace TrabalhoPraticoPWeb1718.Models.ModelosBD
{
    public class Ensino
    {
        public Ensino()
        {
            Instituicoes = new HashSet<Instituicao>();
            Disciplinas = new HashSet<Disciplina>();
            Criancas = new HashSet<Crianca>();
        }
        public int EnsinoId { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Instituicao> Instituicoes { get; set; }
        public virtual ICollection<Disciplina> Disciplinas { get; set; }
        public virtual ICollection<Crianca> Criancas { get; set; }
    }
}