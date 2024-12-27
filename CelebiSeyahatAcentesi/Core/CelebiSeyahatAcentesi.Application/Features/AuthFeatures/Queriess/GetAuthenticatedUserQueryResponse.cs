using CelebiSeyahat.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Application.Features.AuthFeatures.Queriess
{
	public class GetAuthenticatedUserQueryResponse
	{
        public AppUser AppUser { get; set; }
    }
}
