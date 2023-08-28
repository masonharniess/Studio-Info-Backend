//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using StudioInfoAPI.DbContexts;
//using StudioInfoAPI.Models;

//namespace StudioInfoAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class StudiosScaffoldedController : ControllerBase
//    {
//        private readonly StudioContext _context;

//        public StudiosScaffoldedController(StudioContext context)
//        {
//            _context = context;
//        }

//        /// <summary>
//        /// GET: api/StudiosScaffolded
//        /// </summary>
//        /// <returns></returns>
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<StudioModel>>> GetStudios(){
//          if (_context.Studios == null)
//          {
//              return NotFound();
//          }

//          var studios = await _context.Studios.ToListAsync();

//          return Ok(studios); 

//          //return await _context.Studios.ToListAsync();
//        }

//        // GET: api/StudiosScaffolded/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<StudioModel>> GetStudio(long id) {
//          if (_context.Studios == null) 
//          {
//              return NotFound();
//          }
//            var studio = await _context.Studios.FindAsync(id);

//            if (studio == null) // if specific studio is not available
//            {
//                return NotFound();
//            }

//            return studio;
//        }

//        // PUT: api/StudiosScaffolded/5
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutStudio(long id, StudioModel studio){
//            if (id != studio.Id)
//            {
//                return BadRequest();
//            }

//            _context.Entry(studio).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!StudioExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//      return NoContent();
//        }

//      // POST: api/StudiosScaffolded
//      // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//      [HttpPost]
//      public async Task<ActionResult<StudioModel>> PostStudio(StudioModel studio)
//      {
//        if (_context.Studios == null)
//        {
//            return Problem("Entity set 'StudioContext.Studios'  is null.");
//        }
//          _context.Studios.Add(studio);
//          await _context.SaveChangesAsync();

//          return CreatedAtAction(nameof(GetStudio), new { id = studio.Id }, studio);
//      }

//      // DELETE: api/StudiosScaffolded/5
//      [HttpDelete("{id}")]
//      public async Task<IActionResult> DeleteStudio(long id)
//      {
//          if (_context.Studios == null)
//          {
//              return NotFound();
//          }
//          var studio = await _context.Studios.FindAsync(id);
//          if (studio == null)
//          {
//              return NotFound();
//          }

//          _context.Studios.Remove(studio);
//          await _context.SaveChangesAsync();

//          return NoContent();
//      }

//      private bool StudioExists(long id)
//      {
//        return (_context.Studios?.Any(e => e.Id == id)).GetValueOrDefault();
//      }
//    }
//}
