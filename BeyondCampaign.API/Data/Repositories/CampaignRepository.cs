using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BeyondCampaign.API.Data
{
    public class CampaignRepository : ICampaignRepository
    {
        private readonly DataContext _context;

        public CampaignRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> CampaignExists(int id)
        { 
            return await _context.Campaigns.AnyAsync(x => x.Id == id);
        }
    }
}
