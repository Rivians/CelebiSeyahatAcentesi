using CelebiSeyahat.Application.Features.AuthFeatures.Commands.Login;
using CelebiSeyahat.Application.Features.AuthFeatures.Commands.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Application.Services
{
    public interface IAuthService
    {
        //Task RegisterAsync();

        Task<LoginCommandResponse> LoginAsync(LoginCommand loginCommand, CancellationToken cancellationToken);

        Task RegisterAsync(RegisterCommand registerCommand, CancellationToken cancellationToken);

        //Task<LoginCommandResponse> CreateTokenByRefreshTokenAsync()
    }
}
