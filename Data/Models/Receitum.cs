using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Receitum
    {
        public Receitum()
        {
            Complementos = new HashSet<Complemento>();
            Produtos = new HashSet<Produto>();
        }

        public string Filial { get; set; } = null!;
        public int IdReceita { get; set; }
        public DateTime? DatCad { get; set; }
        public string? NomeReceita { get; set; }
        public decimal? QntdReceita { get; set; }
        public string? DELETE { get; set; }

        public virtual ICollection<Complemento> Complementos { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
