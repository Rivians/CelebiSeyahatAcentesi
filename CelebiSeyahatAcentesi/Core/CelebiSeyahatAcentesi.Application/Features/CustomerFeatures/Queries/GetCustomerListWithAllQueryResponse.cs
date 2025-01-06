using CelebiSeyahat.Domain.Entities;
using CelebiSeyahat.Domain.Enums;
using CelebiSeyehat.Dto.HotelReservation;
using CelebiSeyehat.Dto.Payment;
using CelebiSeyehat.Dto.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Application.Features.CustomerFeatures.Queries
{
    public class GetCustomerListWithAllQueryResponse
    {
        // Customer 
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? TcNo { get; set; }
        public string? Gender { get; set; }
        public DateTime? CreatedTime { get; set; }

        public List<TicketDto> Ticket { get; set; }
        public List<HotelReservationDto> HotelReservation { get; set; }
        public List<PaymentDto> Payment { get; set; }
    }
}
