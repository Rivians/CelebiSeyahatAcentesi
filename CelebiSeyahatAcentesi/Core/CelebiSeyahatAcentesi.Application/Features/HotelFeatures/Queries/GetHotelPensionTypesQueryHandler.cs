using CelebiSeyahat.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Application.Features.HotelFeatures.Queries
{
	public class GetHotelPensionTypesQueryHandler : IRequestHandler<GetHotelPensionTypesQuery, List<GetHotelPensionTypesQueryResponse>>
	{
		private readonly IEnumService _enumService;
		public GetHotelPensionTypesQueryHandler(IEnumService enumService)
		{
			_enumService = enumService;
		}

		public async Task<List<GetHotelPensionTypesQueryResponse>> Handle(GetHotelPensionTypesQuery request, CancellationToken cancellationToken)
		{
			var pensionList = _enumService.GetPensionTypes();
			var responseList = pensionList.Select(p => new GetHotelPensionTypesQueryResponse { Name = p }).ToList();	
			return responseList;
		}
	}
}
