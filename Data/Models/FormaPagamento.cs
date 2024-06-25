using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class FormaPagamento
    {
        public FormaPagamento()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int Filial { get; set; }
        public int IdPagamento { get; set; }
        public string? NomePagamento { get; set; }
        public decimal? Taxa { get; set; }
        public string? TipoPagamento { get; set; }
        public string? ContaBancaria { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
