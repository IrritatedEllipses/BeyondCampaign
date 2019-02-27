using System;
using System.Collections.Generic;
using System.Linq;
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
            var exists = await _context.Campaigns.FindAsync(id);

            if (exists.Id > 0)
            {
                return true;
            }
            return false;
        }
    }
}
