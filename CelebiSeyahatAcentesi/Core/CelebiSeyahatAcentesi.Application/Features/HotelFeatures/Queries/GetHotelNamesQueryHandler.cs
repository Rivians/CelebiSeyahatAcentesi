using CelebiSeyahat.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Application.Features.HotelFeatures.Queries
{
    public class GetHotelNamesQueryHandler : IRequestHandler<GetHotelNamesQuery, List<string>>
    {
        private readonly IHotelService _service;
        public GetHotelNamesQueryHandler(IHotelService service)
        {
            _service = service;
        }

        public Task<List<string>> Handle(GetHotelNamesQuery request, CancellationToken cancellationToken)
        {
            return _service.GetHotelNamesAsync();
        }
    }
}
