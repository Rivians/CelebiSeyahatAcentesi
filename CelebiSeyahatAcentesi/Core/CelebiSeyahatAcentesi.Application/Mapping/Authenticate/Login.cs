using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CelebiSeyahat.Application.Features.AuthFeatures.Commands.Login;
using CelebiSeyahat.Domain.Constants;

namespace CelebiSeyahat.Application.Mapping.Authenticate
{
    public class Login : Profile
    {
        public Login()
        {
            CreateMap<Token, LoginCommandResponse>().ReverseMap();  
        }
    }
}
