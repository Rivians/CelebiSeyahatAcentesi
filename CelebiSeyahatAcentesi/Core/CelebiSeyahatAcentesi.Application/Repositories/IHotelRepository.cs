using CelebiSeyahat.Domain.Entities;
using CelebiSeyahat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Application.Repositories
{
    public interface IHotelRepository
    {
        Task<List<Hotel>> GetHotelListByFilterAsync(string location, DateTime? checkInDate, DateTime? checkOutDate, int? guestCount, string hotelName, List<string> features, int? minPrice, int? maxPrice, int? minRating, int? maxRating, PensionType? pensionType);
    }
}
