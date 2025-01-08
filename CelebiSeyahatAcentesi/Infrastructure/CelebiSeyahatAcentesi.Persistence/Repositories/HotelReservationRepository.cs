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
	public class HotelReservationRepository : IHotelReservationRepository
	{
		private readonly CelebiSeyehatDbContext _context;
		public HotelReservationRepository(CelebiSeyehatDbContext context)
		{
			_context = context;
		}

		public async Task<HotelReservation> GetHotelReservationByRoomIdAsync(string roomId)
		{
			return await _context.HotelReservations
				.Include(hr => hr.HotelRoom)
				.ThenInclude(r => r.RoomType)
				.Where(hr => hr.HotelRoomId == roomId).FirstOrDefaultAsync();
		}

	}
}
