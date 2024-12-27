using CelebiSeyahat.Application.Abstractions;
using CelebiSeyahat.Application.Repositories;
using CelebiSeyahat.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Application.Features.TripFeatures.Queries
{
	public class GetTripByIdQueryHandler : IRequestHandler<GetTripByIdQuery, GetTripByIdQueryResponse>
	{
		private readonly ITripRepository _tripRepository;
		public GetTripByIdQueryHandler(ITripRepository tripRepository)
		{
			_tripRepository = tripRepository;
		}


		public async Task<GetTripByIdQueryResponse> Handle(GetTripByIdQuery request, CancellationToken cancellationToken)
		{
			var trip = await _tripRepository.GetTripWithTicketByIdAsync(request.Id);

			return new GetTripByIdQueryResponse
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
				TransportationType = trip.TransportationType.ToString(),
				TicketPrice = trip.Tickets.FirstOrDefault()?.Price  				
			};
		}
	}
}
