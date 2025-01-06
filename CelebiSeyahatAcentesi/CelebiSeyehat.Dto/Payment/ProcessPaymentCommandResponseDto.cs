using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyehat.Dto.Payment
{
	public class ProcessPaymentCommandResponseDto
	{
		public string PaymentId { get; set; }  // Ödeme ID'si
		public string IyzicoCheckoutFormContent { get; set; }
		public bool IsSuccess { get; set; }
		public string Message { get; set; }
		public string Token { get; set; }
	}
}
