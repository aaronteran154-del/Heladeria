using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Heladeria;

namespace api_helados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecetaProductosController : ControllerBase
    {
        private readonly HeladeriaDbContext _context;

        public RecetaProductosController(HeladeriaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecetaProducto>>> GetRecetaProductos()
        {
            return await _context.RecetaProductos
                .Include(r => r.Producto)
                .Include(r => r.Inventario)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RecetaProducto>> GetRecetaProducto(int id)
        {
            var recetaProducto = await _context.RecetaProductos
                .Include(r => r.Producto)
                .Include(r => r.Inventario)
                .FirstOrDefaultAsync(r => r.IdReceta == id);

            if (recetaProducto == null) return NotFound();
            return recetaProducto;
        }

        [HttpPost]
        public async Task<ActionResult<RecetaProducto>> PostRecetaProducto(RecetaProducto recetaProducto)
        {
            _context.RecetaProductos.Add(recetaProducto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetRecetaProducto), new { id = recetaProducto.IdReceta }, recetaProducto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecetaProducto(int id, RecetaProducto recetaProducto)
        {
            if (id != recetaProducto.IdReceta) return BadRequest();
            _context.Entry(recetaProducto).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.RecetaProductos.Any(e => e.IdReceta == id)) return NotFound();
                else throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecetaProducto(int id)
        {
            var recetaProducto = await _context.RecetaProductos.FindAsync(id);
            if (recetaProducto == null) return NotFound();
            _context.RecetaProductos.Remove(recetaProducto);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}