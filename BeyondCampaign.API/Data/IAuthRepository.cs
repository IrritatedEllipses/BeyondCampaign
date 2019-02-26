using System.Threading.Tasks;
using BeyondCampaign.API.Dtos;
using BeyondCampaign.API.Models;

namespace BeyondCampaign.API.Data
{
    public interface IAuthRepository
    {
         Task<User> Register(UserForRegisterDto userForRegisterDto);
         Task<User> Login(string username, string password);
         Task<bool> UserExists(string username);
         Task<int> FindUserIdByUsername();
         Task<string> GenerateJWT(User user);
    }
}