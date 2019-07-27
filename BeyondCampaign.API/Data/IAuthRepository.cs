using System.Threading.Tasks;
using BeyondCampaign.API.Dtos;
using BeyondCampaign.API.Models;

namespace BeyondCampaign.API.Data
{
    public interface IAuthRepository
    {
         Task<User> Register(UserForRegisterDto userForRegisterDto);
         string GenerateJWT(User user);
    }
}