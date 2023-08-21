using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudioInfoAPI.DbContexts;
using StudioInfoAPI.Models;

namespace StudioInfoAPI.Controllers {
  [ApiController]
  [Route("api/[controller]")]
  public class StudiosController : ControllerBase {

    private readonly StudioContext _context;

    public StudiosController(StudioContext context) {
      _context = context;
    }


    [HttpGet] // GETs collection of studios
    public async Task<ActionResult<IEnumerable<Studio>>> GetStudios() {

      if (_context.Studios == null) {
        return NotFound();
      }

      return await _context.Studios.ToListAsync();
    }

    [HttpGet("{id}")] // GETs a specific studio
    public async Task<ActionResult<Studio>> GetStudio(long id) {

      if (_context.Studios == null) { // if collection is not available.
        return NotFound();
      }

      var studio = await _context.Studios.FindAsync(id);

      if (studio == null) { // if specific studio is not available.
        return NotFound();
      }

      return studio;
    }

    [HttpPost] // Creates a new studio
    public async Task<ActionResult<Studio>> CreateStudio(Studio studio) {

      if (_context.Studios == null) {
        return NotFound(); // Entity set 'StudioContext.Studios' is null.
      }

      _context.Studios.Add(studio);
      await _context.SaveChangesAsync();

      return CreatedAtAction(nameof(GetStudio), new { id = studio.Id }, studio);
    }

    [HttpPut("{id}")] // Fully updates a studio
    public async Task<ActionResult> UpdateStudio(long id, Studio studio) {
      
      if (id != studio.Id) { 
        return BadRequest();
      }

      _context.Entry(studio).State = EntityState.Modified; // inform EF's change tracker that studio has been modified and needs updating in the database when changes are saved.

      try {
        await _context.SaveChangesAsync();
      } 
      catch (DbUpdateConcurrencyException) {
        if (!StudioExists(id)) {
          return NotFound();
        }
        else {
          throw;
        }
      }

      return NoContent();
    }

    private bool StudioExists(long id) {
      return (_context.Studios?.Any(e => e.Id == id)).GetValueOrDefault();
    }


  }
}