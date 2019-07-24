using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace BeyondCampaign.API.Models
{
    public class CampaignModelMapping
    {
        public int Id { get; set; }
        public int CampaignId { get; set; }
        public List<SessionNote> SessionNotes { get; set; }

        public CampaignModelMapping()
        {
            SessionNotes = new List<SessionNote>();
        }
    }
}
