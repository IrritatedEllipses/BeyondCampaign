using System.Collections.Generic;

namespace BeyondCampaign.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Email { get; set; }
        public bool? isGM { get; set; }
        public bool? isPlayer { get; set; }




    }
}