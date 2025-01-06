using CelebiSeyahat.Application.Repositories;
using CelebiSeyahat.Domain.Entities;
using CelebiSeyahat.Domain.Enums;
using CelebiSeyahat.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Persistence.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly CelebiSeyehatDbContext _context;
        public HotelRepository(CelebiSeyehatDbContext context)
        {
            _context = context;
        }

        public async Task<List<Hotel>> GetHotelListByFilterAsync(string? location, DateTime? checkInDate, DateTime? checkOutDate, int? guestCount, string? hotelName, List<string>? features, int? minPrice, int? maxPrice, int? minRating, int? maxRating, PensionType? pensionType)
        {
            var query = _context.Hotels
                .Include(h => h.HotelRooms)
                .ThenInclude(r => r.HotelReservations)
                .Include(h => h.HotelFeatures)
                .AsQueryable();

            // Location
            if (!string.IsNullOrEmpty(location))
            {
                query = query.Where(h => h.Location.Contains(location));
            }

            // HotelName
            if (!string.IsNullOrEmpty(hotelName))
            {
                query = query.Where(h => h.Name.Contains(hotelName));

            }

            // Tarihlerin sadece birebir eşleşmesi gereken durumlar nadirdir. Genellikle, belirtilen tarihlerde çakışmayan odaları kontrol etmek daha mantıklıdır. #############

            if (checkInDate.HasValue && checkOutDate.HasValue)
            {
                query = query.Where(h => h.HotelRooms.Any(r => r.HotelReservations.All(res =>
                    (res.CheckOutDate <= checkInDate || res.CheckInDate >= checkOutDate)
                )));
            }
            else if (checkInDate.HasValue)
            {
                query = query.Where(h => h.HotelRooms.Any(r => r.HotelReservations.All(res =>
                    res.CheckOutDate <= checkInDate
                )));
            }
            else if (checkOutDate.HasValue)
            {
                query = query.Where(h => h.HotelRooms.Any(r => r.HotelReservations.All(res =>
                    res.CheckInDate >= checkOutDate
                )));
            }

            // GuestCount
            if (guestCount.HasValue)
            {
                query = query.Where(h => h.Reservations.All(r => r.NumberOfAdults == guestCount));
            }

            // HotelFeatures
            if (features != null && features.Any())
            {
                query = query.Where(h => h.HotelFeatures.Any(f => features.Contains(f.Name)));
            }

            // MinPrice
            if (minPrice.HasValue)
            {
                query = query.Where(h => h.HotelRooms.Any(r => r.Price >= minPrice));
            }

            // MaxPrice
            if (maxPrice.HasValue)
            {
                query = query.Where(h => h.HotelRooms.Any(r => r.Price <= maxPrice));
            }

            // MinRating
            if (minRating.HasValue)
            {
                query = query.Where(h => h.GuestRating >= minRating);
            }

            // MaxRating
            if (maxRating.HasValue)
            {
                query = query.Where(h => h.GuestRating <= maxRating);
            }

            // PensionType
            if (pensionType.HasValue)
            {
                query = query.Where(h => h.PensionType == pensionType.Value);
            }

            return await query.ToListAsync();
        }
    }
}
