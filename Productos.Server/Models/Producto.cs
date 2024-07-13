namespace Productos.Server.Models
{
    public class Producto
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string Descripcion { get; set; } = null!;

        public decimal precio { get; set; } 
    }
}
