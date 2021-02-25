using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroPedidos.Models
{
    public class Ordenes
    {
        [Key]
        public int OrdenId { get; set; }
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "Debe debe agreglar un suplidor obligatorio.")]
        public int SuplidorId { get; set; }
        public decimal Monto { get; set; }

        [ForeignKey("OrdenId")]
        public virtual List<OrdenesDetalle> Detalle { get; set; }

        public Ordenes()
        {
            Fecha = DateTime.Now;
            Detalle = new List<OrdenesDetalle>();
        }
    }
}
