using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using ModeloDatos;
using Clientes.DA;
using System.Transactions;

namespace Clientes.BL
{
    public class ClsBClientes
    {
        ClsDClientes clsDAClientes = new ClsDClientes();
        public List<ModeloDatos.Entidades.Clientes> ConsultaClientes()
        {
            return clsDAClientes.ConsultaClientes();
        }

        public List<ModeloDatos.Entidades.Clientes> ConsultaClienteByIdentificacion(string Identificacion)
        {
            return clsDAClientes.ConsultaClienteByIdentificacion(Identificacion);
        }

        public ModeloDatos.Clientes ConsultaClienteByIdentificacion2(string Identificacion)
        {
            return clsDAClientes.ConsultaClienteByIdentificacion2(Identificacion);
        }

        public int RegistroCliente(ModeloDatos.Clientes NewCliente)
        {
            int grabado = 0;

            using (TransactionScope trans = new TransactionScope())
            {
                clsDAClientes.RegistroCliente(NewCliente);
                trans.Complete();
                grabado = 1;
            }

            return grabado;
        }

        public int ActualizaNombresClientes(int IdCliente, string Nombres, string Apellidos)
        {
            int grabado = 0;

            using (TransactionScope trans = new TransactionScope())
            {
                clsDAClientes.ActualizaNombresClientes(IdCliente, Nombres, Apellidos);
                trans.Complete();
                grabado = 1;
            }

            return grabado;
        }
     
    }
}
