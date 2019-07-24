using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeyondCampaign.API.Data
{
    public interface IUsersRepository
    {
        Task<int> GetUserIdByUserName(string username);
        Task<bool> IsUserNameAvailable(string username);
    }
}
