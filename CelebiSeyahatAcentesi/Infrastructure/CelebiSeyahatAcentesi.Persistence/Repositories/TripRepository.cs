using CelebiSeyahat.Application.Repositories;
using CelebiSeyahat.Domain.Entities;
using CelebiSeyahat.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Persistence.Repositories
{
	public class TripRepository : ITripRepository
	{
		private readonly CelebiSeyehatDbContext _context;
		public TripRepository(CelebiSeyehatDbContext context)
		{
			_context = context;
		}

        public async Task<List<Trip>> GetTripListWithAllAsync()
        {
            var tripList = await _context.Trips.Include(t => t.TransportationCompany).ToListAsync();
			return tripList;
        }

        public async Task<Trip> GetTripWithTicketByIdAsync(string tripId)
		{
			var trip = await _context.Trips.Include(t => t.Tickets).Where(t => t.Id == tripId).FirstOrDefaultAsync();
			return trip;
		}
	}
}
