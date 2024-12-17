using CelebiSeyahat.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Application.Features.AuthFeatures.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand>
    {
        private readonly IAuthService _authService;
        public RegisterCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            await _authService.RegisterAsync(request, cancellationToken);
        }
    }
}
