using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeyondCampaign.API.Models
{
    public class SessionNote
    {
        public int Id { get; set; }

        [Required]
        public Campaign CampaignId { get; set; }

        public DateTime? DateOfSession { get; set; }

        [Required]
        public DateTime DateLogCreated { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Body { get; set; }

        [Required]
        public User Author { get; set; }

        public DateTime LastUpdated { get; set; }
        public User[] TaggedUsers { get; set; }

        public SessionNote()
        {
            this.DateLogCreated = DateTime.Now;
            this.LastUpdated = DateTime.Now;
        }
    }
}
