using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeyondCampaign.API.Models
{
    public class Campaign
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public User Creator { get; set; }
        public User[] Players { get; set; }
    }
}
