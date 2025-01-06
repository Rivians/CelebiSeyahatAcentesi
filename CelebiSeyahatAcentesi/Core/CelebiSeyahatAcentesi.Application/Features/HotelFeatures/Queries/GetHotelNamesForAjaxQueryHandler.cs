using CelebiSeyahat.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Application.Features.HotelFeatures.Queries
{
    public class GetHotelNamesForAjaxQueryHandler : IRequestHandler<GetHotelNamesForAjaxQuery, List<GetHotelNamesForAjaxQueryResponse>>
    {
        private readonly IHotelService _hotelService;
        public GetHotelNamesForAjaxQueryHandler(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        public async Task<List<GetHotelNamesForAjaxQueryResponse>> Handle(GetHotelNamesForAjaxQuery request, CancellationToken cancellationToken)
        {
            var hotelNames = await _hotelService.GetHotelNamesForAjax(request.Search);
         
            var response = hotelNames.Select(name => new GetHotelNamesForAjaxQueryResponse { HotelName = name }).ToList();

            return response;
        }
    }
}
