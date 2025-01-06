using CelebiSeyahat.Domain.Entities;
using CelebiSeyahat.Domain.Enums;
using CelebiSeyehat.Dto.Trip;

namespace CelebiSeyahat.Application.Features.TransportationCompany
{
    public class GetTransportationListWithAllQueryResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string TransportationType { get; set; }


        public List<TripDto> Trip { get; set; }
    }
}