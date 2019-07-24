using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeyondCampaign.API.Data;
using BeyondCampaign.API.Models;
using BeyondCampaign.API.Models.DTOs;

namespace BeyondCampaign.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionNotesController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ISessionNotesRepository _noteRepo;
        private readonly ICampaignRepository _campaignRepo;

        public SessionNotesController(DataContext context, ISessionNotesRepository noteRepo, ICampaignRepository campaignRepo)
        {
            _context = context;
            _noteRepo = noteRepo;
            _campaignRepo = campaignRepo;
        }

        // GET: api/SessionNotes
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSessionNotes([FromRoute] int campaignId)
        {
            if (await _campaignRepo.CampaignExists(campaignId)) 
            {
                var sessionNotes = await _noteRepo.GetSessionNotes(campaignId);
                return Ok(sessionNotes);
            }          

            return BadRequest();
        }

        // GET: api/SessionNotes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSessionNote([FromRoute] int id)
        {
            var noteExists = await _noteRepo.NoteExists(id);

            if (noteExists)
            {
                var sessionNote = await _noteRepo.GetSessionNote(id);
                return Ok(sessionNote);
            }

            return BadRequest();
        }

        // PUT: api/SessionNotes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSessionNote([FromRoute] int id, [FromBody] SessionNoteDto sessionNoteDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sessionNoteDto.Id)
            {
                return BadRequest();
            }

            await _noteRepo.Update(sessionNoteDto);

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

            await _noteRepo.Add(sessionNote);

            return CreatedAtAction("GetSessionNote", new { id = sessionNote.Id }, sessionNote);
        }

        // DELETE: api/SessionNotes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSessionNote([FromRoute] int id)
        {
            if (!await _noteRepo.NoteExists(id))
            {
                return NotFound();
            }

            await _noteRepo.Delete(id);

            return Ok();
        }

        private bool SessionNoteExists(int id)
        {
            return _context.SessionNotes.Any(e => e.Id == id);
        }
    }
}