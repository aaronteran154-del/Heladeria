using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Heladeria; // Asegúrate de que este sea el namespace donde está tu HeladeriaDbContext
using HeladeriaWeb.Models;

namespace HeladeriaWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly HeladeriaDbContext _context;

        public AccountController(HeladeriaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            // Si ya hay sesión iniciada, lo mandamos directo al Home
            if (HttpContext.Session.GetInt32("ClienteId") != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                ModelState.AddModelError("", "Por favor ingresa un correo electrónico.");
                return View();
            }

            // Buscamos al cliente en PostgreSQL por su email
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Email == email);

            if (cliente != null)
            {
                // Guardamos sus datos en la sesión (incluyendo el email para validar el panel admin)
                HttpContext.Session.SetInt32("ClienteId", cliente.IdCliente);
                HttpContext.Session.SetString("ClienteNombre", cliente.Nombre);
                HttpContext.Session.SetString("ClienteEmail", cliente.Email); // <-- Línea clave añadida

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Correo no registrado. Regístrate o contacta al administrador.");
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}