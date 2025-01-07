using CelebiSeyahat.Application.Features.LocationFeatures.Queries;
using CelebiSeyahat.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Application.Features.HotelFeatures.Queries
{
	public class GetHotelFeaturesQueryHandler : IRequestHandler<GetHotelFeaturesQuery, List<GetHotelFeaturesQueryResponse>>
	{
		private readonly IHotelFeatureService _hotelFeatureService;
		public GetHotelFeaturesQueryHandler(IHotelFeatureService hotelFeatureService)
		{
			_hotelFeatureService = hotelFeatureService;
		}

		public async Task<List<GetHotelFeaturesQueryResponse>> Handle(GetHotelFeaturesQuery request, CancellationToken cancellationToken)
		{
			var featureList = await _hotelFeatureService.GetHotelFeaturesAsync();
			return featureList.Select(c => new GetHotelFeaturesQueryResponse()
			{
				Name = c.Name,
			}).ToList();
		}
	}
}
