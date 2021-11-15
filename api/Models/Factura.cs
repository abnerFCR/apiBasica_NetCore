using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Factura
    {
        [Key]
        public int idFactura { get; set; }

        public string Fecha { get; set; }

        public string nitCliente { get; set; }

        public int idEstado { get; set; }

        public Double total { get; set; }

    }
}
