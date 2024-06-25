using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Motoboy
    {
        public int Filial { get; set; }
        public int IdMotob { get; set; }
        public string? Nome { get; set; }
        public decimal? Valor { get; set; }
        public decimal? Taxa { get; set; }
        public string? Moto { get; set; }
        public string? Placa { get; set; }
    }
}
