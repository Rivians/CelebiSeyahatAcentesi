using MediatR;

namespace CelebiSeyahat.Application.Features.TripFeatures.Queries
{
    public class GetFilteredTripsQuery : IRequest<List<GetFilteredTripsQueryResponse>>
    {
        public string FromCity { get; set; }
        public string ToCity { get; set; }
        public DateTime Date { get; set; }
        public int PassengerCount { get; set; }
        public int TransportationType { get; set; }
    }
}
