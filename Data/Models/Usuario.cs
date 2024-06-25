using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Caixas = new HashSet<Caixa>();
        }

        public string? Filial { get; set; }
        public int IdUsuario { get; set; }
        public string LoginUsuario { get; set; } = null!;
        public int Nivel { get; set; }
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public decimal? Comissao { get; set; }
        public string? Telefone { get; set; }
        public string Cpf { get; set; } = null!;
        public string SenhaPass { get; set; } = null!;
        public DateTime? DataCad { get; set; }
        public string? DELETE { get; set; }
       
        public virtual ICollection<Caixa> Caixas { get; set; }
    }
}
