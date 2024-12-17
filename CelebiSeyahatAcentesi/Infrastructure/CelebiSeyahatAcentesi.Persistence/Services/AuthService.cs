using AutoMapper;
using CelebiSeyahat.Application.Abstractions;
using CelebiSeyahat.Application.Features.AuthFeatures.Commands.Login;
using CelebiSeyahat.Application.Features.AuthFeatures.Commands.Register;
using CelebiSeyahat.Application.Services;
using CelebiSeyahat.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Persistence.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        //private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AuthService(UserManager<AppUser> userManager, ITokenService tokenService, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public async Task<LoginCommandResponse> LoginAsync(LoginCommand loginCommand, CancellationToken cancellationToken)
        {
            AppUser? user = await _userManager.Users.Where(x => x.Email == loginCommand.Email).FirstOrDefaultAsync(cancellationToken);

            if (user == null) throw new Exception("Kullanıcı bulunamadı!");

            //var signInResult = await _signInManager.CheckPasswordSignInAsync(user, loginCommand.Password, lockoutOnFailure : false);

            var result = await _userManager.CheckPasswordAsync(user, loginCommand.Password);
            if (result)
            {
                var token = _tokenService.GenerateToken(user);
                LoginCommandResponse response = _mapper.Map<LoginCommandResponse>(token);
                return response;
            }
            else { throw new Exception("Hatalı giriş!"); } 
        }

        public async Task RegisterAsync(RegisterCommand registerCommand, CancellationToken cancellationToken)
        {
            AppUser appUser = _mapper.Map<AppUser>(registerCommand);
            IdentityResult result = await _userManager.CreateAsync(appUser, registerCommand.Password);
            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.FirstOrDefault().Description);
            }
        }
    }
}
