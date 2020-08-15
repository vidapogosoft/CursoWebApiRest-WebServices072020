﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using DemoDevWebApi.Interfaces;
using DemoDevWebApi.Services;

using ModeloDatos;

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
        [HttpPost]
        public IHttpActionResult RegistroCliente([FromBody]ModeloDatos.Clientes NewCliente)
        {
            if (ModelState.IsValid)
            {
                _ClientesRepository.PostCliente(NewCliente);

                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT: api/Clientes2/5
        [HttpPut]
        public IHttpActionResult ActualizaCliente([FromBody]ModeloDatos.Clientes UpdCliente)
        {
            if (ModelState.IsValid)
            {
                _ClientesRepository.PutCliente(UpdCliente);

                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE: api/Clientes2/5
        [HttpDelete]
        public IHttpActionResult DeleteCliente([FromBody] ModeloDatos.Clientes DelCliente)
        {
            if (ModelState.IsValid)
            {
                _ClientesRepository.DeleteCliente(DelCliente);

                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
