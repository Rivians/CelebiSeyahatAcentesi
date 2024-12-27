using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Application.Features.AuthFeatures.Commands.Role
{
    public class AddRoleCommand : IRequest
    {
        public string Role { get; set; }
    }
}
