using CelebiSeyahat.Domain.Entities;
using CelebiSeyahat.Domain.Enums;

namespace CelebiSeyahat.Application.Services
{
    public interface IHotelService
    {
        Task<List<Hotel>> GetHotelListByFilterAsync(string location, DateTime? checkInDate, DateTime? checkOutDate, int? guestCount, string? hotelName, List<string>? features, int? minPrice, int? maxPrice, int? minRating, int? maxRating, PensionType? pensionType);

        Task<List<string>> GetHotelNamesForAjax(string term);

        Task<List<string>> GetHotelNamesAsync();

        Task<Hotel> GetHotelByIdAsync(string id);
	}

}
