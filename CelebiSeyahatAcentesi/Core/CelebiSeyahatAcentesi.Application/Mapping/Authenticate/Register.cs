using AutoMapper;
using CelebiSeyahat.Application.Features.AuthFeatures.Commands.Register;
using CelebiSeyahat.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Application.Mapping.Authenticate
{
    public class Register : Profile
    {
        public Register()
        {
            CreateMap<RegisterCommand, AppUser>().ReverseMap();
        }
    }
}
