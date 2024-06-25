using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Cupon
    {
        public int Filial { get; set; }
        public int IdCupom { get; set; }
        public string CodigoCupom { get; set; } = null!;
        public string NomeCupom { get; set; } = null!;
        public decimal? ValorDesconto { get; set; }
        public string? TipoDesconto { get; set; }
    }
}
