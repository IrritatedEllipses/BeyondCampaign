using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BeyondCampaign.API.Models;
using BeyondCampaign.API.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BeyondCampaign.API.Data
{
    public class SessionNoteRepository : ISessionNotesRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly ICampaignRepository _campaignRepo;

        public SessionNoteRepository(DataContext context, IMapper mapper, ICampaignRepository campaignRepo)
        {
            _context = context;
            _mapper = mapper;
            _campaignRepo = campaignRepo;
        }

        public async Task<SessionNote> Add(SessionNote sessionNote)
        {
            sessionNote.DateLogCreated = DateTime.Now;

            _context.Add(sessionNote);
            await _context.SaveChangesAsync();

            return sessionNote;
        }

        public async Task<bool> Delete(int id)
        {
            var sessionNoteToRemove = GetSessionNote(id);
            _context.Remove(sessionNoteToRemove);
            if (await _context.SaveChangesAsync() > 0)
                return true;

            return false;
        }

        public async Task<SessionNote> Update(SessionNoteDto sessionNoteDto)
        {
            var noteToUpdateFromDb = await _context.SessionNotes
                .FirstOrDefaultAsync(x => x.Id == sessionNoteDto.Id);

            SessionNote noteToDb = _mapper.Map<SessionNoteDto, SessionNote>(sessionNoteDto);

            _context.Add(noteToDb);
            await _context.SaveChangesAsync();

            return noteToDb;
        }

        public async Task<SessionNote> GetSessionNote(int id)
        {
            var noteToReturn = await _context.SessionNotes.FirstOrDefaultAsync(x => x.Id == id);
            return noteToReturn;
        }

        public async Task<List<SessionNote>> GetSessionNotes(int campaignId)
        {
            var campignToGetNotesFrom = await _context.CampaignModelMappings.Include(x => x.SessionNotes)
                .FirstOrDefaultAsync(x => x.CampaignId == campaignId);
            return campignToGetNotesFrom.SessionNotes;  
        }

        public async Task<bool> NoteExists(int id)
        {
            var note = await _context.SessionNotes.AnyAsync(x => x.Id == id);
            return (note);
        }
    }
}
