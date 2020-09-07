using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsumeWebApiCore.Models
{
    public class ClientesExternos
    {
        public int IdCliente { get; set; }
        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string NombresCompletos { get; set; }
        public DateTime? FechaRegistro{ get; set; }

    }
}