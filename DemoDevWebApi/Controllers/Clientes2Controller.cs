using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using DemoDevWebApi.Interfaces;
using DemoDevWebApi.Services;

namespace DemoDevWebApi.Controllers
{

    public class Clientes2Controller : ApiController
    {
        private readonly IClientesRepository _ClientesRepository = new ClientesRepository();

        // GET: api/Clientes2
        [HttpGet]
        public IHttpActionResult GetClientes()
        {
            return Ok(_ClientesRepository.GetClientes);
        }

        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Clientes2/5
        [HttpGet]
        public IHttpActionResult GetClientes(string id)
        {
            return Ok(_ClientesRepository.GetClienteByIdentificacion(id));
        }

        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Clientes2
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Clientes2/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Clientes2/5
        public void Delete(int id)
        {
        }
    }
}
