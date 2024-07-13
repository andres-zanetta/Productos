using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Productos.Server.Models
{
    public class Producto
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "El campo {0} debe tner como maximo {1} caracteres.")]
        public string Nombre { get; set; } = null!;

        [DataType(DataType.MultilineText)]//para que me permita agregar varias lineas de texto
        [MaxLength(500, ErrorMessage = "El campo {0} debe tner como maximo {1} caracteres.")]
        public string Descripcion { get; set; } = null!;

        [Column(TypeName = "decimal (18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]//fromato de moneda
        public decimal Precio { get; set; } 
    }
}
