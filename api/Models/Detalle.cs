using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Detalle
    {
        public int idFactura { get; set; }
        
        public int idProducto { get; set; }

        public int cantidad { get; set; }

    }
}
