using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Empresa
    {
        public int IdEmpresa { get; set; }
        public string Filial { get; set; } = null!;
        public string? Cnpj { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public string? Cep { get; set; }
        public string? Cidade { get; set; }
        public string? Bairro { get; set; }
        public string? Pais { get; set; }
        public string? Logradouro { get; set; }
        public int? Numero { get; set; }
        public string? Referencia { get; set; }
        public string? Coordenadas { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public DateTime? DataCad { get; set; }
    }
}
