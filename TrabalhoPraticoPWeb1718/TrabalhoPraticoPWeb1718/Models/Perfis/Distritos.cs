using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrabalhoPraticoPWeb1718.Models.Perfis
{
    public class Distritos
    {
        public const string Aveiro = "Aveiro";
        public const string Beja = "Beja";
        public const string Braga = "Braga";
        public const string Braganca = "Bragança";
        public const string Castelo_Branco = "Castelo Branco";
        public const string Coimbra = "Coimbra";
        public const string Evora = "Évora";
        public const string Faro = "Faro";
        public const string Guarda = "Guarda";
        public const string Leiria = "Leiria";
        public const string Lisboa = "Lisboa";
        public const string Portalegre = "Portalegre";
        public const string Porto = "Porto";
        public const string Santarem = "Santarém";
        public const string Setubal = "Setúbal";
        public const string Viana_do_Castelo = "Viana do Castelo";
        public const string Vila_Real = "Vila Real";
        public const string Viseu = "Viseu";

        public static List<string> GetListaDistritos()
        {
            var lista = new List<string>();
            lista.Add(Aveiro);
            lista.Add(Beja);
            lista.Add(Braga);
            lista.Add(Braganca);
            lista.Add(Castelo_Branco);
            lista.Add(Coimbra);
            lista.Add(Evora);
            lista.Add(Faro);
            lista.Add(Guarda);
            lista.Add(Leiria);
            lista.Add(Lisboa);
            lista.Add(Portalegre);
            lista.Add(Porto);
            lista.Add(Santarem);
            lista.Add(Setubal);
            lista.Add(Viana_do_Castelo);
            lista.Add(Vila_Real);
            lista.Add(Viseu);
            return lista;
        }
    }
}