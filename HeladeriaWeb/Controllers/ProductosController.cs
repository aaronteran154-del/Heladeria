using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Heladeria;

namespace HeladeriaWeb.Controllers
{
    public class ProductosController : Controller
    {
        private readonly HeladeriaDbContext _context;

        public ProductosController(HeladeriaDbContext context)
        {
            _context = context;
        }

        // GET: /Productos
        public async Task<IActionResult> Index()
        {
            var productos = await _context.Productos.ToListAsync();
            return View(productos);
        }
    }
}
