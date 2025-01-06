using CelebiSeyahat.Domain.Abstraction;

namespace CelebiSeyahat.Domain.Entities
{
    public class HotelFeature : BaseEntity
    {
        public string Name { get; set; }


        public List<Hotel> Hotels { get; set; }
    }
}