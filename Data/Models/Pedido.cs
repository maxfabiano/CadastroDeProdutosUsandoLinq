using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Pedido
    {
        public Pedido()
        {
            Caixas = new HashSet<Caixa>();
            RegistroOcorrencia = new HashSet<RegistroOcorrencium>();
            Cliente = new Cliente();
            Complemento = new Complemento();
            Endereco = new Endereco();
            FormaPagamento = new FormaPagamento();

        }

        public string Filial { get; set; } = null!;
        public int IdPed { get; set; }
        public DateTime? DatPed { get; set; }
        public string? Plataforma { get; set; }
        public decimal? TaxaPedido { get; set; }
        public decimal? DescontoPedido { get; set; }
        public decimal? TotalPedido { get; set; }
        public DateTime? DataDespacho { get; set; }
        public DateTime? DataFim { get; set; }
        public string? Obs { get; set; }
        public string? DELETE { get; set; }
        public int IdPedCli { get; set; }
        public int? IdPedEnder { get; set; }
        public int IdPedProd { get; set; }
        public int? IdPedCompl { get; set; }
        public int IdPedPag { get; set; }

        public virtual Cliente Cliente { get; set; } = null!;
        public virtual Complemento? Complemento { get; set; }
        public virtual Endereco? Endereco { get; set; }
        public virtual FormaPagamento FormaPagamento { get; set; } = null!;
        public virtual List<Produto> Produto { get; set; } = null!;
        public virtual ICollection<Caixa> Caixas { get; set; }
        public virtual ICollection<RegistroOcorrencium> RegistroOcorrencia { get; set; }
    }
}
