using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Endereco
    {
        public Endereco()
        {
            Clientes = new HashSet<Cliente>();
            Pedidos = new HashSet<Pedido>();
        }

        public string? Filial { get; set; }
        public int IdEndereco { get; set; }
        public string? Cep { get; set; }
        public string? Cidade { get; set; }
        public string? Bairro { get; set; }
        public string? Pais { get; set; }
        public string? Logradouro { get; set; }
        public string? Numero { get; set; }
        public string? Complemento { get; set; }
        public string? Referencia { get; set; }
        public decimal? TaxaEntrega { get; set; }
        public string? Coordenadas { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public DateTime? DataCad { get; set; }
        public string? DELETE { get; set; }
        public int? ID_EMPRESA { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
