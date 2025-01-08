using CelebiSeyahat.Application.Abstractions;
using CelebiSeyahat.Application.Repositories;
using CelebiSeyahat.Application.Services;
using CelebiSeyahat.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Persistence.Services
{
	public class HotelReservationService : IHotelReservationService
	{
		private readonly IHotelReservationRepository _repository;
		public HotelReservationService(IHotelReservationRepository repository)
		{
			_repository = repository;
		}

		public async Task<HotelReservation> GetHotelReservationByRoomIdAsync(string roomId)
		{		
			return await _repository.GetHotelReservationByRoomIdAsync(roomId);
		}
	}
}
