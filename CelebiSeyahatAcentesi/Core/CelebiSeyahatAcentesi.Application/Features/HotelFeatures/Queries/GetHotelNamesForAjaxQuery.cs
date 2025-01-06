using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Application.Features.HotelFeatures.Queries
{
    public class GetHotelNamesForAjaxQuery : IRequest<List<GetHotelNamesForAjaxQueryResponse>>
    {
        // kullanıcının inputa yazdığı string verisi.
        public string Search { get; set; }
    }
}
