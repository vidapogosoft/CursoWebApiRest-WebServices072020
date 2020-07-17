using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

using TodoASMXService.Services;
using TodoASMXService.Models;

namespace TodoASMXService
{
    /// <summary>
    /// Descripción breve de TodoServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class TodoServices : System.Web.Services.WebService
    {
        static readonly ITodoRepository todoService = new Services.TodoRepository();

        [WebMethod]
        public List<TodoItem> GetTodoItems()
        {
            return todoService.All.ToList();
        }

        [WebMethod]
        public void CreateTodoItem(TodoItem item)
        {
            try
            {
                if (item == null || string.IsNullOrWhiteSpace(item.Name) 
                    || string.IsNullOrWhiteSpace(item.Notes))
                {
                    throw new SoapException("Campos requeridos", SoapException.ClientFaultCode);
                }

                var itemExists = todoService.DoesItemExist(item.ID);
                if (itemExists)
                {
                    
                   throw new SoapException("ID esta en uso", SoapException.ClientFaultCode);

                }

                todoService.Insert(item);

            }
            catch (Exception ex)
            {

                throw new SoapException("Error", SoapException.ServerFaultCode, ex);
            }

        }

        [WebMethod]
        public void EditTodoItem(TodoItem item)
        {
            try
            {
                if (item == null || string.IsNullOrWhiteSpace(item.Name)
                    || string.IsNullOrWhiteSpace(item.Notes))
                {
                    throw new SoapException("Campos requeridos", SoapException.ClientFaultCode);
                }

                var itemExists = todoService.Find(item.ID);
                if (itemExists == null)
                {

                    throw new SoapException("ID no se encuentra", SoapException.ClientFaultCode);

                }
                else
                {
                    todoService.Update(item);
                }


            }
            catch (Exception ex)
            {

                throw new SoapException("Error", SoapException.ServerFaultCode, ex);
            }

        }


        [WebMethod]
        public void DeleteTodoItem(string id)
        {
            try
            {
            
                var itemExists = todoService.Find(id);
                if (itemExists == null)
                {

                    throw new SoapException("ID no se encuentra", SoapException.ClientFaultCode);

                }
                else
                {
                    todoService.Delete(id);
                }


            }
            catch (Exception ex)
            {

                throw new SoapException("Error", SoapException.ServerFaultCode, ex);
            }

        }

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }
    }
}
