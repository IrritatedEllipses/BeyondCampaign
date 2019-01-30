using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeyondCampaign.API.Models
{
    public class SessionNote
    {
        // TODO 
        // Add Campaign type when complete
        // Add Tagging System (Perhaps in campaign instead of here?
        public int Id { get; set; }
        //public Campaign CampaignName { get; set; }
        public DateTime DateOfSession { get; set; }
        public DateTime DateLogCreated { get; set; }
        public DateTime LastUpdated { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public User Author { get; set; }
        public User[] TaggedUsers { get; set; }
    }
}
