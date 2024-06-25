using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Complemento
    {
        public Complemento()
        {
            Pedidos = new HashSet<Pedido>();
            Produtos = new HashSet<Produto>();
        }

        public string? Filial { get; set; }
        public int IdCompl { get; set; }
        public string? NomeCompl { get; set; }
        public string? CategCompl { get; set; }
        public decimal? ValorCusto { get; set; }
        public decimal? ValorVenda { get; set; }
        public string? CodIntegrador { get; set; }
        public decimal? QntdCompl { get; set; }
        public byte[]? Foto { get; set; }
        public DateTime? DatCad { get; set; }
        public string? DELETE { get; set; }
        public int? IdReceitCompl { get; set; }
        public string? DataCusto { get; set; }

        public virtual Receitum? IdReceitComplNavigation { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
