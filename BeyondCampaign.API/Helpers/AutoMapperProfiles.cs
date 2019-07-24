using AutoMapper;
using BeyondCampaign.API.Dtos;
using BeyondCampaign.API.Models;
using BeyondCampaign.API.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeyondCampaign.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserForRegisterDto, User>();
            CreateMap<SessionNoteDto, SessionNote>();
            CreateMap<SessionNote, SessionNoteDto>();
        }
    }
}
