using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeyondCampaign.API.Models.DTOs
{
    public class SessionNoteDto
    {
        public int Id { get; set; }

        public int CampaignId { get; set; }

        public DateTime? DateOfSession { get; set; }
        public List<User> TaggedUsers { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Body { get; set; }

        [Required]
        public User Author { get; set; }
    }
}
