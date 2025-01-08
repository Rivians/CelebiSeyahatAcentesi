using AutoMapper;
using CelebiSeyahat.Application.Services;
using CelebiSeyehat.Dto.HotelReservation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Application.Features.HotelFeatures.Queries
{
	public class GetHotelReservationByHotelRoomIdQueryHandler : IRequestHandler<GetHotelReservationByHotelRoomIdQuery, GetHotelReservationByHotelRoomIdQueryResponse>
	{
		private readonly IHotelReservationService _hotelReservationService;
		private readonly IMapper _mapper;
		public GetHotelReservationByHotelRoomIdQueryHandler(IHotelReservationService hotelReservationService, IMapper mapper)
		{
			_hotelReservationService = hotelReservationService;
			_mapper = mapper;
		}

		public async Task<GetHotelReservationByHotelRoomIdQueryResponse> Handle(GetHotelReservationByHotelRoomIdQuery request, CancellationToken cancellationToken)
		{
			var hotelReservation = await _hotelReservationService.GetHotelReservationByRoomIdAsync(request.Id);
			var mappedResponse = _mapper.Map<GetHotelReservationByHotelRoomIdQueryResponse>(hotelReservation);
			return mappedResponse;
		}
	}
}
