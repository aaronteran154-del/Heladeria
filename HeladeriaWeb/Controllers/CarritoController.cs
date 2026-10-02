using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Heladeria; // Asegúrate de que este sea el namespace donde está tu HeladeriaDbContext
using HeladeriaWeb.Models;

namespace HeladeriaWeb.Controllers
{
    public class CarritoController : Controller
    {
        private readonly HeladeriaDbContext _context;

        public CarritoController(HeladeriaDbContext context)
        {
            _context = context;
        }

        // Método auxiliar para obtener el carrito de la sesión
        private List<CarritoItem> ObtenerCarrito()
        {
            var carrito = HttpContext.Session.GetObjectFromJson<List<CarritoItem>>("Carrito") ?? new List<CarritoItem>();
            return carrito;
        }

        // Método auxiliar para guardar el carrito en la sesión
        private void GuardarCarrito(List<CarritoItem> carrito)
        {
            HttpContext.Session.SetObjectAsJson("Carrito", carrito);
        }

        // GET: /Carrito
        public IActionResult Index()
        {
            var carrito = ObtenerCarrito();
            return View(carrito);
        }

        // POST: /Carrito/Agregar
        [HttpPost]
        public async Task<IActionResult> Agregar(int productoId, int cantidad = 1)
        {
            var producto = await _context.Productos.FindAsync(productoId);
            if (producto == null)
            {
                return NotFound();
            }

            var carrito = ObtenerCarrito();
            var item = carrito.FirstOrDefault(p => p.ProductoId == productoId);

            if (item == null)
            {
                carrito.Add(new CarritoItem
                {
                    ProductoId = producto.IdProducto, // Asegúrate de que tu propiedad ID en Producto se llame Id
                    NombreProducto = producto.Nombre, // Asegúrate del nombre exacto de la propiedad en tu modelo Producto
                    Precio = producto.PrecioVenta, // Asegúrate del nombre exacto de la propiedad de precio
                    Cantidad = cantidad
                });
            }
            else
            {
                item.Cantidad += cantidad;
            }

            GuardarCarrito(carrito);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Carrito/Limpiar
        public IActionResult Limpiar()
        {
            HttpContext.Session.Remove("Carrito");
            return RedirectToAction(nameof(Index));
        }

        // POST: /Carrito/SimularCheckout
        [HttpPost]
        public IActionResult SimularCheckout()
        {
            HttpContext.Session.Remove("Carrito");
            TempData["Mensaje"] = "¡Compra simulada con éxito! Gracias por tu preferencia en la heladería.";
            return RedirectToAction("Index", "Productos");
        }
    }
}