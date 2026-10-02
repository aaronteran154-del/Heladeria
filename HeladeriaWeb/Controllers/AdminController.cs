using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Heladeria; // Namespace donde está tu HeladeriaDbContext y tus modelos

namespace HeladeriaWeb.Controllers
{
    public class AdminController : Controller
    {
        private readonly HeladeriaDbContext _context;
        private const string CorreoAdmin = "afteranc@utn.edu.ec";

        public AdminController(HeladeriaDbContext context)
        {
            _context = context;
        }

        // Método privado para validar si el usuario actual es el administrador
        private bool EsAdministrador()
        {
            var emailSesion = HttpContext.Session.GetString("ClienteEmail");
            return emailSesion == CorreoAdmin;
        }

        // ==================== DASHBOARD PRINCIPAL ====================
        public IActionResult Index()
        {
            if (!EsAdministrador())
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        // ==================== GESTIÓN DE PRODUCTOS ====================

        // GET: Admin/Productos
        public async Task<IActionResult> Productos()
        {
            if (!EsAdministrador()) return RedirectToAction("Login", "Account");

            var productos = await _context.Productos.ToListAsync();
            return View(productos);
        }

        // GET: Admin/CrearProducto
        [HttpGet]
        public IActionResult CrearProducto()
        {
            if (!EsAdministrador()) return RedirectToAction("Login", "Account");
            return View();
        }

        // POST: Admin/CrearProducto
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearProducto(Producto producto)
        {
            if (!EsAdministrador()) return RedirectToAction("Login", "Account");

            if (ModelState.IsValid)
            {
                _context.Productos.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Productos));
            }
            return View(producto);
        }

        // GET: Admin/EditarProducto/5
        [HttpGet]
        public async Task<IActionResult> EditarProducto(int id)
        {
            if (!EsAdministrador()) return RedirectToAction("Login", "Account");

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        // POST: Admin/EditarProducto/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarProducto(int id, Producto producto)
        {
            if (!EsAdministrador()) return RedirectToAction("Login", "Account");

            if (id != producto.IdProducto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Productos.Any(e => e.IdProducto == producto.IdProducto))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Productos));
            }
            return View(producto);
        }

        // GET: Admin/EliminarProducto/5
        [HttpGet]
        public async Task<IActionResult> EliminarProducto(int id)
        {
            if (!EsAdministrador()) return RedirectToAction("Login", "Account");

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        // POST: Admin/EliminarProductoConfirmado
        [HttpPost, ActionName("EliminarProductoConfirmado")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarProductoConfirmado(int id)
        {
            if (!EsAdministrador()) return RedirectToAction("Login", "Account");

            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Productos));
        }

        // ==================== GESTIÓN DE CLIENTES ====================

        // GET: Admin/Clientes
        public async Task<IActionResult> Clientes()
        {
            if (!EsAdministrador()) return RedirectToAction("Login", "Account");

            var clientes = await _context.Clientes.ToListAsync();
            return View(clientes);
        }

        // GET: Admin/CrearCliente
        [HttpGet]
        public IActionResult CrearCliente()
        {
            if (!EsAdministrador()) return RedirectToAction("Login", "Account");
            return View();
        }

        // POST: Admin/CrearCliente
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearCliente(Cliente cliente)
        {
            if (!EsAdministrador()) return RedirectToAction("Login", "Account");

            if (ModelState.IsValid)
            {
                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Clientes));
            }
            return View(cliente);
        }

        // GET: Admin/EditarCliente/5
        [HttpGet]
        public async Task<IActionResult> EditarCliente(int id)
        {
            if (!EsAdministrador()) return RedirectToAction("Login", "Account");

            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Admin/EditarCliente/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarCliente(int id, Cliente cliente)
        {
            if (!EsAdministrador()) return RedirectToAction("Login", "Account");

            if (id != cliente.IdCliente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Clientes.Any(e => e.IdCliente == cliente.IdCliente))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Clientes));
            }
            return View(cliente);
        }

        // GET: Admin/EliminarCliente/5
        [HttpGet]
        public async Task<IActionResult> EliminarCliente(int id)
        {
            if (!EsAdministrador()) return RedirectToAction("Login", "Account");

            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Admin/EliminarClienteConfirmado
        [HttpPost, ActionName("EliminarClienteConfirmado")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarClienteConfirmado(int id)
        {
            if (!EsAdministrador()) return RedirectToAction("Login", "Account");

            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Clientes));
        }
    }
}