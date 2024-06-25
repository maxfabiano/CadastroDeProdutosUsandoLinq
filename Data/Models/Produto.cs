using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Produto
    {
        public Produto()
        {
            Pedidos = new HashSet<Pedido>();
        }
        public string Filial { get; set; } = null!;
        public int IdProd { get; set; }
        public int CODEMP { get; set; }
        public int CODFIL { get; set; }

        public string? NomeProd { get; set; }
        public string? CategProd { get; set; }
        public string? SubcategProd { get; set; }
        public decimal? ValorCusto { get; set; }
        public decimal? ValorVenda { get; set; }
        public string? CodIntegrador { get; set; }
        public DateTime? DatCad { get; set; }
        public int? IdProdCompl { get; set; }
        public int? IdProdReceita { get; set; }
        public string? DELETE { get; set; }
        public string? img { private get; set; }

        public byte[]? Foto { get; set; }

        public virtual Complemento? IdProdComplNavigation { get; set; }
        public virtual Receitum? IdProdReceitaNavigation { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }

        public void fotoConvert()
        {
            if (img == null)
            {
                Foto = null;
            }
            else
            {
                var offset = img.IndexOf(',') + 1;
                Foto = Convert.FromBase64String(img[offset..^0]);
            }
        }
    }

}
