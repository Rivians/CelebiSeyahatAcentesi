using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Application.Features.AuthFeatures.Commands.Role
{
    public class AssignRoleCommand : IRequest
    {
        public string AppUserId { get; set; }
        public string Role { get; set; }
    }
}
