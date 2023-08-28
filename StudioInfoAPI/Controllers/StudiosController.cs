﻿using Microsoft.AspNetCore.JsonPatch;
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
    public async Task<ActionResult<Studio>> PostStudio(Studio studio) {

      if (_context.Studios == null) {
        return NotFound(); // Entity set 'StudioContext.Studios' is null.
      }

      _context.Studios.Add(studio);
      await _context.SaveChangesAsync();

      return CreatedAtAction(nameof(GetStudio), new { id = studio.Id }, studio);
    }

    [HttpPut("{id}")] // Fully update a studio
    public async Task<ActionResult> PutStudio(long id, Studio studio) {

      if (id != studio.Id) {
        return BadRequest();
      }

      // inform EF's change tracker that studio has been modified and needs updating in the database when changes are saved.
      _context.Entry(studio).State = EntityState.Modified;

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

    [HttpPatch("{id}")] // Partially update a studio
    public async Task<ActionResult> PatchStudio([FromRoute] long id, [FromBody] JsonPatchDocument<Studio> patchDocument) {

      // fetch the existing studio from the database with the provided id
      var existingStudio = _context.Studios.FirstOrDefault(s => s.Id == id);

      if (existingStudio == null) {
        return NotFound();
      }

      patchDocument.ApplyTo(existingStudio);

      // mark studio as modified in the EF context
      _context.Update(existingStudio);

      try {
        // saves changes made to the database
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

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteStudio(long id) {

      var studio = await _context.Studios.FindAsync(id);

      if (studio == null) {
        return NotFound();
      }

      _context.Studios.Remove(studio);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool StudioExists(long id) {
      return (_context.Studios?.Any(e => e.Id == id)).GetValueOrDefault();
    }

  }
}