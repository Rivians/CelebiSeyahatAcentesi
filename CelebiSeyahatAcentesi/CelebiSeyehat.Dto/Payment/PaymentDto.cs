using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyehat.Dto.Payment
{
	public class PaymentDto
	{
        public string Id { get; set; }
		public string Amount { get; set; }
		public DateTime PaymentDate { get; set; }
		public string PaymentMethod { get; set; }
		public string CustomerId { get; set; }
		public string TicketId { get; set; }  
		public string HotelReservationId { get; set; }  
		public string TransactionId { get; set; }  
		public string ErrorMessage { get; set; } 
		public string PaymentStatus { get; set; }
        public DateTime? CreatedTime { get; set; } = DateTime.UtcNow;
    }
}
