using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class EstadoFactura
    {
        [Key]
        public int idEstado { get; set; }

        public string estado { get; set; }
    }
}
