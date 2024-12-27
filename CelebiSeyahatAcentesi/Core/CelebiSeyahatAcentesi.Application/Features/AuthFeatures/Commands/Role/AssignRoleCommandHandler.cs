using CelebiSeyahat.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Application.Features.AuthFeatures.Commands.Role
{
    public class AssignRoleCommandHandler : IRequestHandler<AssignRoleCommand>
    {
        private readonly IAuthService _authService;

        public AssignRoleCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task Handle(AssignRoleCommand request, CancellationToken cancellationToken)
        {
            await _authService.AssignRoleAsync(request.AppUserId, request.Role);
        }
    }
}