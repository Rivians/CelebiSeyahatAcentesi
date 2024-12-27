using CelebiSeyahat.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Application.Features.LocationFeatures.Queries
{
    public class GetLocationListQueryHandler : IRequestHandler<GetLocationListQuery, List<GetLocationListQueryResponse>>
    {
        private readonly ILocationService _locationService;
        public GetLocationListQueryHandler(ILocationService locationService)
        {
            _locationService = locationService;
        }

        public async Task<List<GetLocationListQueryResponse>> Handle(GetLocationListQuery request, CancellationToken cancellationToken)
        {
            var cityList = await _locationService.GetCityListAsync();
            return cityList.Select(c => new GetLocationListQueryResponse()
            {
                Name = c.Name,
            }).ToList();
        }
    }
}
