using CelebiSeyahat.Domain.Abstraction;
using CelebiSeyahat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Domain.Entities
{
    public class Payment : BaseEntity
    {
        public string Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string CustomerId { get; set; }
		public string TicketId { get; set; }  // Eğer ödeme bilet içinse, TicketId
		public string HotelReservationId { get; set; }  // Eğer ödeme otel rezervasyonu içinse, HotelReservationId
		public string TransactionId { get; set; }  // Iyzico işlem kimliği
		public string ErrorMessage { get; set; }  // Ödeme hatası varsa hata mesajı
		public PaymentStatus PaymentStatus { get; set; }  // Ödeme durumu (Pending, Completed, Failed)


		public Customer Customer { get; set; }
        public Ticket Ticket { get; set; }
        public HotelReservation HotelReservation { get; set; }
    }
}
