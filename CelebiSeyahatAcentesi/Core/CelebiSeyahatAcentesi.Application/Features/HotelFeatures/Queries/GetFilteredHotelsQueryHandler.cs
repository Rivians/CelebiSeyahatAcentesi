using AutoMapper;
using CelebiSeyahat.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Application.Features.HotelFeatures.Queries
{
    public class GetFilteredHotelsQueryHandler : IRequestHandler<GetFilteredHotelsQuery, List<GetFilteredHotelsQueryResponse>>
    {
        private readonly IHotelService _hotelService;
        private readonly IMapper _mapper;
        public GetFilteredHotelsQueryHandler(IHotelService hotelService, IMapper mapper)
        {
            _hotelService = hotelService;
            _mapper = mapper;
        }

        public async Task<List<GetFilteredHotelsQueryResponse>> Handle(GetFilteredHotelsQuery request, CancellationToken cancellationToken)
        {
            var hotelList = await _hotelService.GetHotelListByFilterAsync(
                request.Location,
                request.CheckInDate,
                request.CheckOutDate,
                request.GuestCount,
                request.HotelName,
                request.Features,
                request.MinPrice,
                request.MaxPrice,
                request.MinRating,
                request.MaxRating,
                request.PensionType
                );

            var mappedResponse = _mapper.Map<List<GetFilteredHotelsQueryResponse>>(hotelList);
            return mappedResponse;
        }
    }
}
