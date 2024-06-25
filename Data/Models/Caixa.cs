using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Caixa
    {
        public int Filial { get; set; }
        public int IdCaixa { get; set; }
        public DateTime? DataAbertura { get; set; }
        public decimal? ValorAbertura { get; set; }
        public DateTime? DataFechamento { get; set; }
        public decimal? ValorFechamento { get; set; }
        public decimal? AddCaixa { get; set; }
        public decimal? RetirarCaixar { get; set; }
        public DateTime? DataRetirada { get; set; }
        public string? Descricao { get; set; }
        public int? IdPedCaix { get; set; }
        public int? IdPagamentoCaix { get; set; }
        public int? IdUsuarioCaixa { get; set; }

        public virtual FormaPagamento? IdPagamentoCaixNavigation { get; set; }
        public virtual Pedido? IdPedCaixNavigation { get; set; }
        //public virtual Usuario? IdUsuarioCaixaNavigation { get; set; }
    }
}
