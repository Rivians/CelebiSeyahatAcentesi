using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Application.Features.PaymentFeatures.Commands
{
	public class ProcessPaymentCommand : IRequest<ProcessPaymentCommandResponse>
	{
		// Ödeme Bilgileri 
		//public string CardHolderName { get; set; }		KART BİLGİLER İYZİCO FORM İÇERİSİNDEN DİREKT İYİZO'YA GÖNDERİLİR.
		//public string CardNumber { get; set; }			VERİTABANINDA BOŞUNA TUTULMASINA GEREK YOK.
		//public string ExpireMonth { get; set; }
		//public string ExpireYear { get; set; }
		//public string Cvc { get; set; }


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


		// Para Birimi
		//public string Currency { get; set; }
	}
}
