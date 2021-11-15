using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Producto
    {
        [Key]
        public int idProducto { get; set; }

        public string nombre { get; set; }

        public Double precio { get; set; }


    }
}
