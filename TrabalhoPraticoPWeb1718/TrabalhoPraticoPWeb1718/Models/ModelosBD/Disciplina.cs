namespace TrabalhoPraticoPWeb1718.Models.ModelosBD
{
    public class Disciplina
    {
        public int DisciplinaId { get; set; }
        public string Nome { get; set; }
        public Curso Curso { get; set; }

        public virtual Ensino Ensino { get; set; }
    }

    public enum Curso
    {
        Matematica, Ciencias, Letras, Artes
    }
}