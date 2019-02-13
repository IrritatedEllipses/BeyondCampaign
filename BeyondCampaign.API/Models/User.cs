using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace BeyondCampaign.API.Models
{
    public class User : IdentityUser<int>
    {
        public ICollection<UserRole> UserRoles { get; set; }
        public bool IsPlayer { get; set; }
        public bool isGm { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastActive { get; set; }
    }
}