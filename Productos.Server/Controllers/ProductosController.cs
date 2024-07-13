using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Productos.Server.Models;

namespace Productos.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly ProductosContext _context;

        public ProductosController(ProductosContext context)
        {
            _context = context;

        }

        [HttpPost]
        [Route("Crear")]

        public async Task<IActionResult> CrearProducto(Producto producto)
        {
            await _context.Productos.AddAsync(producto);
            await _context.SaveChangesAsync();

            return Ok();

        }

        [HttpGet]
        [Route ("Listar")]

        public async Task<ActionResult<IEnumerable<Producto>>>ListarProductos()
        {
            var productos = await _context.Productos.ToListAsync();//lista de todos los productos
            return Ok(productos);
        }

        [HttpGet]
        [Route("Observar")]
        public async Task<ActionResult>ObservarProducto(int id)
        {
            Producto producto = await _context.Productos.FindAsync(id);
            if(producto == null)
            {
                return NotFound();
            }
            return Ok(producto);
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<ActionResult> ActualizarProducto(int id, Producto producto)
        {
            var productoExistente = await _context.Productos.FindAsync(id);

            productoExistente!.Nombre = producto.Nombre;
            productoExistente.Descripcion = producto.Descripcion;
            productoExistente.Precio = producto.Precio;

            await _context.SaveChangesAsync();

            return Ok();

        }

    }
}
