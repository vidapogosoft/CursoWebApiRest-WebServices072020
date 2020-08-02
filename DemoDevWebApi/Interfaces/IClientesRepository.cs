﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ModeloDatos;


namespace DemoDevWebApi.Interfaces
{
    public interface IClientesRepository
    {
        IEnumerable<ModeloDatos.Entidades.Clientes> GetClientes { get; }
        
        IEnumerable<ModeloDatos.Entidades.Clientes> GetClienteByIdentificacion(string Identificacion);

        //void PostCliente(ClsClientes NewCiente);

    }
}
