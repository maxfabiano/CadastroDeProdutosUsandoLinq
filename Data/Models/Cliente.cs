using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Pedidos = new HashSet<Pedido>();
            RegistroOcorrencia = new HashSet<RegistroOcorrencium>();
            IdEndCliNavigation = new HashSet<Endereco>();
        }


      public int?CODEMP { get; set;}
      public int? CODFIL{get;set;}
      public int?CODCLI{get;set;}
      public string?NOMCLI{get;set;}
      public string?TELCLI{get;set;}
      public string?DOCCLI{get;set;}
      public string?DATNAS{get;set;}
      public DateTime?DATCAD{get;set;}
      public int? NOTCLI{get;set;}
      public string?OBSCLI{get;set;}
      public string?EMAIL{get;set;}
      public string? CODPWS{get;set;}
      public int?ENDPAD{get;set;}
      public string?MSBLQL{get;set;}
      public string?D_E_L_E_T_{get;set;}
        public virtual ICollection<Endereco>? IdEndCliNavigation { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
        public virtual ICollection<RegistroOcorrencium> RegistroOcorrencia { get; set; }
    }
}
