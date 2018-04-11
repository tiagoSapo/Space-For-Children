using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrabalhoPraticoPWeb1718.Models.ModelosBD
{
    public class Crianca
    {
        public int CriancaId { get; set; }
        public string Nome { get; set; }
        public Genero Genero { get; set; }
        public DateTime DataNascimento { get; set; }
        
        // Devera estar compreendida entre 0 a 20
        public int? Avaliacao { get; set; }
        public DateTime DataContrato { get; set; }

        public virtual Pai Pai { get; set; }
        public virtual Instituicao Instituicao { get; set; }
        public virtual Ensino Ensino { get; set; }
    }
    public enum Genero
    {
        Masculino, Feminino
    }
}