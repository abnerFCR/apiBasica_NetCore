using api.Contexts;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoFacturaController : ControllerBase
    {

        private readonly AppDbContext context;

        public EstadoFacturaController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<EstadoFacturaController>
        [HttpGet]
        public IEnumerable<EstadoFactura> Get()
        {
            return context.EstadoFactura.ToList();
        }

        // GET api/<EstadoFacturaController>/5
        [HttpGet("{id}")]
        public EstadoFactura Get(int id)
        {
            var estadoFactura = context.EstadoFactura.FirstOrDefault(p => p.idEstado== id);
            return estadoFactura;
        }

        /*
        // POST api/<EstadoFacturaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EstadoFacturaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EstadoFacturaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
