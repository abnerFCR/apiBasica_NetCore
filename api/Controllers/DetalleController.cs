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
    public class DetalleController : ControllerBase
    {

        private readonly AppDbContext context;

        public DetalleController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<DetalleController>
        [HttpGet]
        public IEnumerable<Detalle> Get()
        {
            return context.Detalle.ToList();
        }

        // GET api/<DetalleController>/5
        [HttpGet("{idFactura}")]
        public IEnumerable<Detalle> Get(int id)
        {
            var detalleFactura = context.Detalle.Where(d=>(d.idFactura==id));
            return detalleFactura;
        }

        // GET api/<DetalleController>/5
        [HttpGet("{idFactura}/{idProducto}")]
        public IEnumerable<Detalle> GetPro(int idF, int idP)
        {
            var detalleFactura = context.Detalle.Where(d => (d.idFactura == idF  &&  d.idProducto==idP));
            return detalleFactura;
        }

        // POST api/<DetalleController>
        [HttpPost]
        public ActionResult Post([FromBody] Detalle[] detalle)
        {
            try
            {
                foreach (Detalle d in detalle) {
                    context.Detalle.Add(d);
                }
                context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

    }
}
