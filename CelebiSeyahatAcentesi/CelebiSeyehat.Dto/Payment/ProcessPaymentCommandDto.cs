using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyehat.Dto.Payment
{
	public class ProcessPaymentCommandDto
	{
		// Kullanıcı (Buyer) Bilgileri
		public string BuyerId { get; set; }
		public string BuyerName { get; set; }
		public string BuyerSurname { get; set; }
		public string BuyerEmail { get; set; }
		public string BuyerGsmNumber { get; set; }
		public string BuyerIdentityNumber { get; set; }
		public string BuyerIp { get; set; }
		public string BuyerCity { get; set; }
		public string BuyerCountry { get; set; }
		public string BuyerAddress { get; set; }
		public string BuyerZipCode { get; set; }


		// Adres Bilgileri
		public string ShippingAddress { get; set; }
		public string BillingAddress { get; set; }


		// Ödeme Detayları
		public string PaymentId { get; set; }
		public decimal Price { get; set; }
		public decimal PaidPrice { get; set; }
		public string CallbackUrl { get; set; }
	}
}
