using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using ModeloDatos;
using ModeloDatos.Entidades;

namespace Clientes.DA
{
    public class ClsDClientes
    {
        //LINQ = Language Integrated Query

        public List<ModeloDatos.Entidades.Clientes> ConsultaClientes()
        {
            using (DBApirestEntities ctx = new DBApirestEntities())
            {
                var x = (from a in ctx.Clientes
                         orderby a.IdCliente descending
                         select new ModeloDatos.Entidades.Clientes()
                         {
                             IdCliente = a.IdCliente,
                             Identificacion = a.Identificacion,
                             NombresCompletos = a.NombresCompletos
                         }).ToList();

                return x;
            }

        }

        public List<ModeloDatos.Entidades.Clientes> ConsultaClienteByIdentificacion(string Identificacion)
        {
            using (DBApirestEntities ctx = new DBApirestEntities())
            {
                var x = (from a in ctx.Clientes
                         where a.Identificacion == Identificacion
                         select new ModeloDatos.Entidades.Clientes()
                         {
                             IdCliente = a.IdCliente,
                             Identificacion = a.Identificacion,
                             NombresCompletos = a.NombresCompletos
                         }).ToList();

                return x;
            }
        }

        public ModeloDatos.Clientes ConsultaClienteByIdentificacion2(string Identificacion)
        {
            ModeloDatos.Clientes cliente = new ModeloDatos.Clientes();

            using (DBApirestEntities ctx = new DBApirestEntities())
            {
                 cliente = ctx.Clientes.Where(a => a.Identificacion == Identificacion).FirstOrDefault();
            }

            return cliente;
        }

        //public List<ModeloDatos.Entidades.Clientes> ConsultaClienteById(int IdCliente)
        //{

        //}

        //public List<ModeloDatos.Entidades.Clientes> ConsultaClientesPedidos()
        //{

        //}

        //public List<ModeloDatos.Entidades.Clientes> ConsultaClientePedidosById(int IdCliente)
        //{

        //}


        public void RegistroCliente(ModeloDatos.Clientes NewCliente)
        {
            using (DBApirestEntities ctx = new DBApirestEntities())
            {
                ctx.Clientes.Add(NewCliente);
                ctx.SaveChanges();
            }
        }

        public void ActualizaNombresClientes(int IdCliente,string Nombres, string Apellidos)
        {
            using (DBApirestEntities ctx = new DBApirestEntities())
            {
                var cliente = ctx.Clientes.Where(a => a.IdCliente == IdCliente).ToList();

                if (cliente.Count > 0)
                {
                    foreach (ModeloDatos.Clientes clienteModificar in cliente)
                    {
                        clienteModificar.Nombres = Nombres;
                        clienteModificar.Apellidos = Apellidos;
                        clienteModificar.NombresCompletos = Nombres + " " + Apellidos;

                        ctx.SaveChanges();
                    }
                }

            }
        }


    }
}
