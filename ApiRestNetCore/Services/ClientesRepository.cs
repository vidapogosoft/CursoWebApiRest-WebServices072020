using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ApiRestNetCore.Interfaces;
using ApiRestNetCore.Models;

namespace ApiRestNetCore.Services
{
    public class ClientesRepository : IClientes
    {

        public IEnumerable<Clientes> ListClientes
        {
            get { return CargaClientes(); }
        }

        //Accedo al contexto

        public List<Clientes> CargaClientes()
        {
            using ( var context = new DBApirestContext()) 
            {
                return context.Clientes.ToList();
            }
        
        }

        public List<Clientes> GetClienteByIdentificacion(string Identificacion)
        {
            using (var context = new DBApirestContext())
            {
                return context.Clientes.Where(a => a.Identificacion == Identificacion).ToList();
            }
        }

        public void RegistroClientes(Clientes NewCliente)
        {

            using (var context = new DBApirestContext())
            {
                context.Clientes.Add(NewCliente);
                context.SaveChanges();
            }

        }

    }
}
