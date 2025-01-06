using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Application.Features.HotelFeatures.Queries
{
    public class GetFilteredHotelsQueryResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int Price { get; set; }
        public int GuestRating { get; set; }
        public string PensionType { get; set; }
        public List<string> HotelFeatures { get; set; }
    }
}
