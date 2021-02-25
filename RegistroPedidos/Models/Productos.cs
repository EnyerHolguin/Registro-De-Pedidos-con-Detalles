using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroPedidos.Models
{
    public class Productos
    {
        [Key]
        public int ProductoId { get; set; }
        [Required(ErrorMessage = "Debe agregar una descripción")]
        public string Descripcion { get; set; }
        [Range(minimum: 10, maximum: 10000000)]
        public decimal Costo { get; set; }
        [Range(minimum: 1, maximum: 10000000)]
        public float Inventario { get; set; }
    }
}
