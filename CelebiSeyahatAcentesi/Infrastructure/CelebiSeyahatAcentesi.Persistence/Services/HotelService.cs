using CelebiSeyahat.Application.Abstractions;
using CelebiSeyahat.Application.Repositories;
using CelebiSeyahat.Application.Services;
using CelebiSeyahat.Domain.Entities;
using CelebiSeyahat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Persistence.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IRepository<Hotel> _repository;
        public HotelService(IHotelRepository hotelRepository, IRepository<Hotel> repository)
        {
            _hotelRepository = hotelRepository;
            _repository = repository;
        }

        public async Task<List<Hotel>> GetHotelListByFilterAsync(string location, DateTime? checkInDate, DateTime? checkOutDate, int? guestCount, string? hotelName, List<string>? features, int? minPrice, int? maxPrice, int? minRating, int? maxRating, PensionType? pensionType)
        {
            var hotelList = await _hotelRepository.GetHotelListByFilterAsync(location, checkInDate, checkOutDate, guestCount, hotelName, features, minPrice, maxPrice, minRating, maxRating, pensionType);

            return hotelList;
        }

        public async Task<List<string>> GetHotelNamesAsync()
        {
            var hotelList = await _repository.GetAllAsync();
            var hotelNames = hotelList.Select(x => x.Name).ToList();
            return hotelNames;
        }

        public async Task<List<string>> GetHotelNamesForAjax(string term)
        {
            var hotelNames = await _repository.GetAllAsync(h => h.Name.Contains(term));
            return hotelNames.Select(h => h.Name).ToList();
        }
    }
}
