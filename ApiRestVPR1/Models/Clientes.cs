using System;
using System.Collections.Generic;

namespace ApiRestVPR1.Models
{
    public partial class Clientes
    {
        public int IdCliente { get; set; }
        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string NombresCompletos { get; set; }
        public DateTime? FechaRegistro { get; set; }
    }
}
