using BeyondCampaign.API.Models;
using BeyondCampaign.API.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeyondCampaign.API.Data
{
    public interface ISessionNotesRepository
    {
        Task<SessionNote> Add(SessionNote sessionNote);
        Task<bool> Delete(int id);
        Task<SessionNote> Update(SessionNoteDto sessionNoteDto);
        Task<bool> NoteExists(int id);
        Task<List<SessionNote>> GetSessionNotes(int campaignId);
        Task<SessionNote> GetSessionNote(int id);
    }
}
