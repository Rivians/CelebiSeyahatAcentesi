using CelebiSeyahat.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Application.Features.AuthFeatures.Commands.Role
{
    public class AddRoleCommandHandler : IRequestHandler<AddRoleCommand>
    {
        private readonly IAuthService _authService;
        public AddRoleCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            await _authService.AddRoleAsync(request.Role);
        }
    }
}
