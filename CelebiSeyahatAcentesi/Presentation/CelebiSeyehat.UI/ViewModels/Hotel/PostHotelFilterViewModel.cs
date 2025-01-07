namespace CelebiSeyehat.UI.ViewModels.Hotel
{
    public class PostHotelFilterViewModel
    {
        public string Location { get; set; }
        public string? HotelName { get; set; }
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public int GuestCount { get; set; }
        public List<string>? Features { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public int? MinRating { get; set; }
        public int? MaxRating { get; set; }
        public string? PensionType { get; set; }
    }
}
