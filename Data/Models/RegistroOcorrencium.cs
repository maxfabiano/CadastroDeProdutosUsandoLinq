using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class RegistroOcorrencium
    {
        public int Filial { get; set; }
        public int IdRegistro { get; set; }
        public int? Protocolo { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public string? TipoOcorrencia { get; set; }
        public string? SubtipoOcorrencia { get; set; }
        public DateTime? DataRegistro { get; set; }
        public string? DataOcorrido { get; set; }
        public int? IdOcorrPed { get; set; }
        public int? IdOcorrCli { get; set; }

        public virtual Cliente? IdOcorrCliNavigation { get; set; }
        public virtual Pedido? IdOcorrPedNavigation { get; set; }
    }
}
