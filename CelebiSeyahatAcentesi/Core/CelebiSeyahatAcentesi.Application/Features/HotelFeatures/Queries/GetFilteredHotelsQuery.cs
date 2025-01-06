using CelebiSeyahat.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Application.Features.HotelFeatures.Queries
{
    public class GetFilteredHotelsQuery : IRequest<List<GetFilteredHotelsQueryResponse>>
    {
        public string Location { get; set; }
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public int? GuestCount { get; set; }
        public string? HotelName { get; set; }
        public List<string>? Features { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public int? MinRating { get; set; }
        public int? MaxRating { get; set; }
        public PensionType? PensionType { get; set; }
    }
}
