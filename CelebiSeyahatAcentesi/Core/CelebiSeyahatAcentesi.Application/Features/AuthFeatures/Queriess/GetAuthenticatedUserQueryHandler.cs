using CelebiSeyahat.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Application.Features.AuthFeatures.Queriess
{
	public class GetAuthenticatedUserQueryHandler : IRequestHandler<GetAuthenticatedUserQuery, GetAuthenticatedUserQueryResponse>
	{
		private readonly IAuthService _authService;
		public GetAuthenticatedUserQueryHandler(IAuthService authService)
		{
			_authService = authService;
		}

		public async Task<GetAuthenticatedUserQueryResponse> Handle(GetAuthenticatedUserQuery request, CancellationToken cancellationToken)
		{
			var user = await _authService.GetAuthenticatedUserAsync();

			return new GetAuthenticatedUserQueryResponse
			{
				AppUser = user,
			};
		}
	}
}
