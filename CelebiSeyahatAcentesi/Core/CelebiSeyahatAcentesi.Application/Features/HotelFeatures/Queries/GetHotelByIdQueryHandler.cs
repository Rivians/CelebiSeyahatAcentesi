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
	public class GetHotelByIdQueryHandler : IRequestHandler<GetHotelByIdQuery, GetHotelByIdQueryResponse>
	{
		private readonly IHotelService _hotelService;
		private readonly IMapper _mapper;
		public GetHotelByIdQueryHandler(IHotelService hotelService, IMapper mapper)
		{
			_hotelService = hotelService;
			_mapper = mapper;
		}

		public async Task<GetHotelByIdQueryResponse> Handle(GetHotelByIdQuery request, CancellationToken cancellationToken)
		{
			var hotel = await _hotelService.GetHotelByIdAsync(request.Id);
			var response = _mapper.Map<GetHotelByIdQueryResponse>(hotel);
			return response;
		}
	}
}
