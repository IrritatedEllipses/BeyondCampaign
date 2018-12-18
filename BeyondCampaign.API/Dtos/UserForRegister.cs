﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeyondCampaign.API.Dtos
{
    public class UserForRegister
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [StringLength(12,
            MinimumLength = 6,
            ErrorMessage = "Password must be between 6 and 12 characters")]
        public string Password { get; set; }
    }
}
