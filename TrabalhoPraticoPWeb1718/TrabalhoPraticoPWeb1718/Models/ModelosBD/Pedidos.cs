using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrabalhoPraticoPWeb1718.Models.ModelosBD
{
    public class Pedidos
    {
        public int PedidosId { get; set; }
        [Display(Name = "Pai/Mãe")]
        public int PaiId { get; set; }
        [Display(Name = "Instituição")]
        public int InstituicaoId { get; set; }

        [Display(Name = "Mensagem do Pai/Mãe")]
        public string MsgPai { get; set; }
        [Display(Name = "Mensagem da Instituição")]
        public string MsgInstituicao { get; set; }
    }
}