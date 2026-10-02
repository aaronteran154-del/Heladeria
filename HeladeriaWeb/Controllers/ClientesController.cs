using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Heladeria;

namespace HeladeriaWeb.Controllers
{
    public class ClientesController : Controller
    {
        private readonly HeladeriaDbContext _context;

        public ClientesController(HeladeriaDbContext context)
        {
            _context = context;
        }

        // GET: /Clientes
        public async Task<IActionResult> Index()
        {
            var clientes = await _context.Clientes.ToListAsync();
            return View(clientes);
        }
    }
}