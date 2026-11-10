using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrestitiBibliotecaAPI.DTO;
using PrestitiBibliotecaAPI.Models;

namespace PrestitiBibliotecaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentiController : ControllerBase
    {
        private readonly PrestitiBibliotecaApiContext _context;

        public StudentiController(PrestitiBibliotecaApiContext context)
        {
            _context = context;
        }

        // GET: api/Studenti/dto
        [HttpGet("dto")]
        public async Task<ActionResult<IEnumerable<StudenteDTO>>> ElencoStudentiDTO()
        {
            return await _context.Studentes.Select(s => new StudenteDTO(s)).ToListAsync();
        }

        // GET: api/Studenti
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Studente>>> GetStudentes()
        {
            return await _context.Studentes.ToListAsync();
        }

        // GET: api/Studenti/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Studente>> GetStudente(int id)
        {
            var studente = await _context.Studentes.FindAsync(id);

            if (studente == null)
            {
                return NotFound();
            }

            return studente;
        }

        // PUT: api/Studenti/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudente(int id, Studente studente)
        {
            if (id != studente.Matricola)
            {
                return BadRequest();
            }

            _context.Entry(studente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudenteExists(id))
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

        // id, nominativo, classe
        // GET ../searchClasse/{classe}
        [HttpGet("seachClasse/{classe}")]
        public async Task<ActionResult<IEnumerable<StudenteDTO>>> ElencoStudentiInClasse(string classe)
        {
            return await _context.Studentes.Where(s => s.Classe.Equals(classe)).Select(s => StudenteDTO.from(s)).ToListAsync();
        }


        // POST: api/Studenti
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Studente>> PostStudente(Studente studente)
        {
            _context.Studentes.Add(studente);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StudenteExists(studente.Matricola))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStudente", new { id = studente.Matricola }, studente);
        }

        // DELETE: api/Studenti/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudente(int id)
        {
            var studente = await _context.Studentes.FindAsync(id);
            if (studente == null)
            {
                return NotFound();
            }

            _context.Studentes.Remove(studente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudenteExists(int id)
        {
            return _context.Studentes.Any(e => e.Matricola == id);
        }
    }
}
