using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeyondCampaign.API.Data;
using BeyondCampaign.API.Models;

namespace BeyondCampaign.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionNotesController : ControllerBase
    {
        private readonly DataContext _context;

        public SessionNotesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/SessionNotes
        [HttpGet]
        public IEnumerable<SessionNote> GetSessionNotes()
        {
            return _context.SessionNotes;
        }

        // GET: api/SessionNotes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSessionNote([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sessionNote = await _context.SessionNotes.FindAsync(id);

            if (sessionNote == null)
            {
                return NotFound();
            }

            return Ok(sessionNote);
        }

        // PUT: api/SessionNotes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSessionNote([FromRoute] int id, [FromBody] SessionNote sessionNote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sessionNote.Id)
            {
                return BadRequest();
            }

            _context.Entry(sessionNote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SessionNoteExists(id))
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

        // POST: api/SessionNotes
        [HttpPost]
        public async Task<IActionResult> PostSessionNote([FromBody] SessionNote sessionNote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SessionNotes.Add(sessionNote);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSessionNote", new { id = sessionNote.Id }, sessionNote);
        }

        // DELETE: api/SessionNotes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSessionNote([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sessionNote = await _context.SessionNotes.FindAsync(id);
            if (sessionNote == null)
            {
                return NotFound();
            }

            _context.SessionNotes.Remove(sessionNote);
            await _context.SaveChangesAsync();

            return Ok(sessionNote);
        }

        private bool SessionNoteExists(int id)
        {
            return _context.SessionNotes.Any(e => e.Id == id);
        }
    }
}