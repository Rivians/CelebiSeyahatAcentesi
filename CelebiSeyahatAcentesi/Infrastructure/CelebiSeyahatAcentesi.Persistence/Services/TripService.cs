using CelebiSeyahat.Application.Abstractions;
using CelebiSeyahat.Application.Repositories;
using CelebiSeyahat.Application.Services;
using CelebiSeyahat.Domain.Entities;
using CelebiSeyahat.Domain.Enums;
using CelebiSeyahat.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Persistence.Services
{
    public class TripService : ITripService
    {
        private readonly IRepository<Trip> _repository;
		private readonly ITripRepository _tripRepository;

		public TripService(IRepository<Trip> repository, ITripRepository tripRepository)
		{
			_repository = repository;
			_tripRepository = tripRepository;
		}


		public async Task<List<Trip>> GetFilteredTripsAsync(string fromCity, string toCity, DateTime date, int passengerCount, int transportationType)
        {
            var query = await _repository.GetAllQueryableAsync();

            // Taşıma Türü
            if (Enum.IsDefined(typeof(TransportationType), transportationType))  // transportationType değişkeninin TransportType enum'ında tanımlı mı değil mi
            {
                var tripType = (TransportationType)transportationType;
                query = query.Where(t => t.TransportationType == tripType);
            }

            // Nereden
            if (!string.IsNullOrEmpty(fromCity))
            {
                query = query.Where(x => x.Departure.Contains(fromCity));
            }

            // Nereye
            if (!string.IsNullOrEmpty(toCity))
            {
                query = query.Where(x => x.Destination.Contains(toCity));
            }

            // Gidiş Tarihi
            if (date != DateTime.MinValue)  // Eğer kullanıcı tarih girmemişse, tarih değeri DateTime.MinValue olacaktır. Yani aslında nullOrEmpty gibi.
            {
                query = query.Where(t => t.DepartureDate.Day == date.Day);
            }

            // Yolcu Sayısı
            if (passengerCount != 0)
            {
                query = query.Where(t => t.AvailableSeats >= passengerCount);
            }

            return query.Include(t => t.Tickets).ToList();

            //return await query.ToListAsync();
        }

        public async Task<List<Trip>> GetTripListWithAllAsync()
        {
            var tripList = await _tripRepository.GetTripListWithAllAsync();
            return tripList;
        }

        public async Task<Trip> GetTripWithTicketsByIdAsync(string id)
		{
            var trip = await _tripRepository.GetTripWithTicketByIdAsync(id);
            return trip;
		}
	}
}
