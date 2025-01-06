using CelebiSeyahat.Domain.Constants;
using CelebiSeyahat.Domain.Identity;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Application.Abstractions
{
    public interface ITokenService
    {
        Token GenerateToken(AppUser appUser, IList<string> roles);
    }
}
