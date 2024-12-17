using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Application.Features.AuthFeatures.Commands.Login
{
    public class LoginCommandResponse
    {
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
        public string? RefreshToken { get; set; }
    }
}
