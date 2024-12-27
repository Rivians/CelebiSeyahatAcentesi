using CelebiSeyahat.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Application.Services
{
    public interface ITripService
    {
        Task<List<Trip>> GetFilteredTripsAsync(string fromCity, string toCity, DateTime date, int passengerCount, int transportationType);
        Task<Trip> GetTripWithTicketsByIdAsync(string id);
    }
}
