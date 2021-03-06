﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace BeyondCampaign.API.Models
{
    public class SessionNote
    {
        public int Id { get; set; }

        public int CampaignId { get; set; }

        public DateTime? DateOfSession { get; set; }

        public DateTime DateLogCreated { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Body { get; set; }

        [Required]
        public User Author { get; set; }
        public bool Updated { get; set; } = false;

        public DateTime LastUpdated { get; set; }
        public User[] TaggedUsers { get; set; }

        public SessionNote()
        {
            this.DateLogCreated = DateTime.Now;
            this.LastUpdated = DateTime.Now;           
        }
    }
}
