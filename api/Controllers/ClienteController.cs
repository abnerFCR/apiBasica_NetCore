using api.Contexts;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly AppDbContext context;

        public ClienteController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<ClienteController>
        [HttpGet]
        public IEnumerable<Cliente> Get()
        {
            return context.Cliente.ToList();
        }

        // GET api/<ClienteController>/5
        [HttpGet("{nit}")]
        public Cliente Get(string nit)
        {
            var cliente = context.Cliente.FirstOrDefault(p => p.nitCliente.Equals(nit));
            return cliente;
        }

        // POST api/<ClienteController>
        [HttpPost]
        public ActionResult Post([FromBody] Cliente cliente)
        {
            try
            {
                context.Cliente.Add(cliente);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }

        }

        // PUT api/<ClienteController>/5
        [HttpPut("{nit}")]
        public ActionResult Put(int nit, [FromBody] Cliente cliente)
        {
            if (cliente.nitCliente.Equals(nit))
            {
                context.Entry(cliente).State = EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{nit}")]
        public ActionResult Delete(int nit)
        {
            var cliente = context.Cliente.FirstOrDefault(p => p.nitCliente.Equals(nit));
            if (cliente != null)
            {
                context.Cliente.Remove(cliente);
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();

            }
        }
    }
}
