using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Application.Features.PaymentFeatures.Commands
{
	public class ProcessPaymentCommandResponse
	{
		public string PaymentId { get; set; }  // Ödeme ID'si
        public string IyzicoCheckoutFormContent { get; set; }
        public bool IsSuccess { get; set; }
		public string Message { get; set; }
	}
}
