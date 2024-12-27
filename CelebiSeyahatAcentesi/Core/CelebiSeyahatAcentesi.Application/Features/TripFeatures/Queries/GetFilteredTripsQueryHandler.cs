using CelebiSeyahat.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Application.Features.TripFeatures.Queries
{
    public class GetFilteredTripsQueryHandler : IRequestHandler<GetFilteredTripsQuery ,List<GetFilteredTripsQueryResponse>>
    {
        private readonly ITripService _tripService;
        public GetFilteredTripsQueryHandler(ITripService tripService)
        {
            _tripService = tripService;
        }

        public async Task<List<GetFilteredTripsQueryResponse>> Handle(GetFilteredTripsQuery request, CancellationToken cancellationToken)
        {
            var trips = await _tripService.GetFilteredTripsAsync(
                request.FromCity,
                request.ToCity,
                request.Date,
                request.PassengerCount,
                request.TransportationType);

            var response = trips.Select(trip => new GetFilteredTripsQueryResponse
            {
                Id = trip.Id,
                Departure = trip.Departure,
                Destination = trip.Destination,
                DepartureDate = trip.DepartureDate,
                ArrivalDate = trip.ArrivalDate,
                TotalSeats = trip.TotalSeats,
                AvailableSeats = trip.AvailableSeats,
                CompanyCoverImageUrl = trip.CompanyCoverImageUrl,
                TransportationCompanyId = trip.TransportationCompanyId,
                TransportationType = trip.TransportationType.ToString(), // enum'u string olarak parse ettik.
                TicketPrice = trip.Tickets.FirstOrDefault().Price  // o seferib tüm biletlerinin fiyatı aynı olacağı için ilkini seçebiliriz
            }).ToList();

            return response;
        }
    }
}
