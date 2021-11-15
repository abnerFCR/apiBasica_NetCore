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
    public class FacturaController : ControllerBase
    {
        private readonly AppDbContext context;

        public FacturaController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<FacturaController>
        [HttpGet]
        public IEnumerable<Factura> Get()
        {
            DateTime a = new DateTime();
            Console.WriteLine(a);
            return context.Factura.ToList();
        }

        // GET api/<FacturaController>/5
        [HttpGet("{id}")]
        public Factura Get(int id)
        {
            var factura = context.Factura.FirstOrDefault(f=>(f.idFactura == id));
            return factura;
        }

        // GET api/<FacturaController>/5
        [HttpGet("{nit}")]
        public IEnumerable<Factura> Get(string nit)
        {
            var factura = context.Factura.Where(f => (f.nitCliente.Equals(nit)));
            return factura;
        }
        /*
        // GET api/<FacturaController>/5
        [HttpGet("{inicio}/{fin}")]
        public IEnumerable<Factura> Get(string inicio, string fin)
        {/*
            var factura = context.Factura.Where(f => (f.Fecha>=inicio && f.Fecha<=fin));
            return factura;
        
        }
        */
        // POST api/<FacturaController>
        [HttpPost]
        public ActionResult Post([FromBody] Factura factura)
        {
            try
            {
                context.Factura.Add(factura);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        // PUT api/<FacturaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Factura factura)
        {
            if (factura.idFactura == id)
            {
                context.Entry(factura).State = EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<FacturaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var factura = context.Factura.FirstOrDefault(p => p.idFactura== id);
            if (factura != null)
            {
                var detalles = context.Detalle.Where(p => (p.idFactura == id));
                foreach (Detalle d in detalles)
                {
                    context.Detalle.Remove(d);
                }
                context.Factura.Remove(factura);
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
