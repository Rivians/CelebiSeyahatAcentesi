using AutoMapper;
using CelebiSeyahat.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Application.Features.TripFeatures.Queries
{
    public class GetTripListWithAllQueryHandler : IRequestHandler<GetTripListWithAllQuery, List<GetTripListWithAllQueryResponse>>
    {
        private readonly ITripService _tripService;
        private readonly IMapper _mapper;
        public GetTripListWithAllQueryHandler(ITripService tripService, IMapper mapper)
        {
            _tripService = tripService;
            _mapper = mapper;
        }

        public async Task<List<GetTripListWithAllQueryResponse>> Handle(GetTripListWithAllQuery request, CancellationToken cancellationToken)
        {
            var tripList = await _tripService.GetTripListWithAllAsync();
            var response = _mapper.Map<List<GetTripListWithAllQueryResponse>>(tripList);

            return response;
        }
    }
}
