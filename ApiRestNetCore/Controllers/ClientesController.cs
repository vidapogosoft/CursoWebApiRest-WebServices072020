using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

using ApiRestNetCore.Interfaces;
using ApiRestNetCore.Models;

namespace ApiRestNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClientes _IClientes;

        public ClientesController(IClientes IClientes)
        {
            _IClientes = IClientes;
        }

        // GET: api/<ClientesController
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_IClientes.ListClientes);
        }

        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<ClientesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ClientesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ClientesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
