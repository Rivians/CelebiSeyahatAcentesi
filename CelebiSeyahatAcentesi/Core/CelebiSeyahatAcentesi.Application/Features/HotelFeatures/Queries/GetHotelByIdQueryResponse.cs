using CelebiSeyehat.Dto.HotelFeature;
using CelebiSeyehat.Dto.HotelReservation;
using CelebiSeyehat.Dto.HotelRoom;
using CelebiSeyehat.Dto.HotelType;

namespace CelebiSeyahat.Application.Features.HotelFeatures.Queries
{
	public class GetHotelByIdQueryResponse
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Location { get; set; }
		public decimal GuestRating { get; set; }
		public string PensionType { get; set; }
		public List<string> HotelFeatures { get; set; }
		public string CoverImageUrl { get; set; }



		public List<HotelRoomDto> HotelRooms { get; set; }
		public List<HotelReservationDto> Reservations { get; set; }
		public List<RoomTypeDto> RoomTypes { get; set; }
		public List<HotelFeatureDto> HotelFeaturess { get; set; }
	}
}