using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeyondCampaign.API.Models
{
    public class Campaign
    {
        // TODO:
        // Extend Campaign (NPCs, Items, Locations, etc...etc...)
        // Add Requirements for 
        public int Id { get; set; }
        public string Name { get; set; }
        public int CreatorId { get; set; }
        public User Creator { get; set; }
        public List<User> Players { get; set; }
        public CampaignModelMapping SessionNotesList { get; set; }
        public Campaign()
        {
            SessionNotesList.CampaignId = Id;
        }
    }
}
