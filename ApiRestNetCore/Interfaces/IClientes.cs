using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ApiRestNetCore.Models;

namespace ApiRestNetCore.Interfaces
{
    public interface IClientes
    {

        IEnumerable<Clientes> ListClientes { get;  }

        void RegistroClientes(Clientes NewCliente);
    }
}
