using BeyondCampaign.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeyondCampaign.API.Data
{
    public interface ISessionNotesRepository
    {
        Task<SessionNote> Add(SessionNote sessionNote);
        Task<SessionNote> Delete(SessionNote sessionNote);
        Task<SessionNote> Update(SessionNote sessionNote);
        Task<IEnumerable<SessionNote>> GetSessionNotes();
        Task<SessionNote> GetSessionNote();
    }
}
