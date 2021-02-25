using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroPedidos.Models
{
    public class Suplidores
    {
        [Key]
        public int SuplidorId { get; set; }
        [Required(ErrorMessage = "Debe agregar un nombre del suplidor.")]
        public string Nombres { get; set; }
    }
}
