using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrestitiBibliotecaAPI.DTO;
using PrestitiBibliotecaAPI.Models;

namespace PrestitiBibliotecaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibriController : ControllerBase
    {
        private readonly PrestitiBibliotecaApiContext _context;

        public LibriController(PrestitiBibliotecaApiContext context)
        {
            _context = context;
        }

        // GET: api/Libroes
        [HttpGet("elencoDTO")]
        public async Task<ActionResult<IEnumerable<LibroDTO>>> ElencoLibriDTO()
        {
            var elenco = _context.Libros.Select(l => new LibroDTO
            {
                Id = l.Codice,
                Autore = l.Autore,
                Titolo = l.Titolo,
                Editore = l.Editore,
                Anno = l.Anno,
                Classificazione = l.Classificazione
            });

            return await elenco.ToListAsync();
        }


        // GET: api/Libroes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Libro>>> GetLibri()
        {
            return await _context.Libros.ToListAsync();
        }

        // GET: api/Libroes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Libro>> GetLibro(int id)
        {
            var libro = await _context.Libros.FindAsync(id);

            if (libro == null)
            {
                return NotFound();
            }

            return libro;
        }

        // PUT: api/Libroes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibro(int id, Libro libro)
        {
            if (id != libro.Codice)
            {
                return BadRequest();
            }

            _context.Entry(libro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibroExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Libroes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Libro>> PostLibro(Libro libro)
        {
            _context.Libros.Add(libro);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LibroExists(libro.Codice))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLibro", new { id = libro.Codice }, libro);
        }

        // DELETE: api/Libroes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibro(int id)
        {
            var libro = await _context.Libros.FindAsync(id);
            if (libro == null)
            {
                return NotFound();
            }

            _context.Libros.Remove(libro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LibroExists(int id)
        {
            return _context.Libros.Any(e => e.Codice == id);
        }
    }
}
