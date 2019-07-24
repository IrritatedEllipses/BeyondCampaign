using BeyondCampaign.API.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeyondCampaign.API.Data
{
    public class UsersRepository : IUsersRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly DataContext _context;

        public UsersRepository(UserManager<User> userManager, DataContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<int> GetUserIdByUserName(string username)
        {
            var user = await _userManager.FindByNameAsync(username);

            return user.Id;
        }

        public async Task<bool> IsUserNameAvailable(string username)
        {
            var user = await _context.Users.FindAsync(username);

            return user.Id > 0 ? true : false;
        }
    }
}
