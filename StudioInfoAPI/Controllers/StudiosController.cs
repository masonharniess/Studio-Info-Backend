using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudioInfoAPI.DbContexts;
using StudioInfoAPI.Models;

namespace StudioInfoAPI.Controllers
{
  [ApiController]
  [Route("api/studios")]
  public class StudiosController : ControllerBase
  {

    private readonly StudioContext _context;

    public StudiosController(StudioContext context) {
      _context = context;
    }

    /// <summary>
    /// Get Studiosji
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Studio>>> GetStudios() { 
      if (_context.Studios == null) { 
        return NotFound();
      }
      return await _context.Studios.ToListAsync();
    } 
  }
}
