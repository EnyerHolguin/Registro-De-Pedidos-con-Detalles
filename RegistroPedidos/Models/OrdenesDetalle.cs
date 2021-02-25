using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroPedidos.Models
{
    public class OrdenesDetalle
    {
        [Key]
        public int Id { get; set; }
        public int OrdenId { get; set; }
        public  decimal Cantidad{ get; set; }
        public decimal Costo { get; set; }
        

        [ForeignKey("OrdenId")]
        public virtual Productos Producto { get; set; }
    }
}
