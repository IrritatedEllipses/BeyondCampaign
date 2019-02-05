using AutoMapper;
using BeyondCampaign.API.Dtos;
using BeyondCampaign.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeyondCampaign.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public static void AutoMapperProfiles()
        {
            CreateMap<UserForRegisterDto, User>();
        }
    }
}
