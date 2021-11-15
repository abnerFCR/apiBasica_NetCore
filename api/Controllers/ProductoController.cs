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
    public class ProductoController : ControllerBase
    {
        private readonly AppDbContext context;

        public ProductoController(AppDbContext context) 
        {
            this.context = context;
        }

        // GET: api/<ProductoController>
        [HttpGet]
        public IEnumerable<Producto> Get()
        {
            return context.Producto.ToList();
        }

        // GET api/<ProductoController>/5
        [HttpGet("{idProducto}")]
        public Producto Get(int idProducto)
        {
            var producto = context.Producto.FirstOrDefault(p => p.idProducto == idProducto);
            return producto;
       
        }

        // POST api/<ProductoController>
        [HttpPost]
        public ActionResult Post([FromBody] Producto producto)
        {
            try
            {
                context.Producto.Add(producto);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }

        }

        // PUT api/<ProductoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Producto producto)
        {
            if (producto.idProducto == id)
            {
                context.Entry(producto).State = EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            else 
            {
                return BadRequest();
            }
            
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var producto = context.Producto.FirstOrDefault(p => p.idProducto == id);
            if (producto != null)
            {
                context.Producto.Remove(producto);
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
