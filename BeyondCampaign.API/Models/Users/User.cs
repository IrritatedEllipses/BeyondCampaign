using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace BeyondCampaign.API.Models
{
    public class User : IdentityUser<int>
    {
        public string UserDisplayName { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public bool IsPlayer { get; set; }
        public bool IsGm { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastActive { get; set; }

        public User()
        {
            DateCreated = DateTime.Now;
        }
    }

}