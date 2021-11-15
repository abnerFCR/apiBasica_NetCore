using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Cliente
    {
        [Key]
        public string nitCliente { get; set; }

        public string nombre{ get; set; }
    }
}
