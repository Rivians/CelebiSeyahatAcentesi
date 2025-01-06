using CelebiSeyahat.Application.Abstractions;
using CelebiSeyahat.Application.Features.PaymentFeatures.Commands;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Infrastructure.Services
{
	public class IyzicoPaymentService : IPaymentService
	{
		private readonly string apiKey = "sandbox-ea0DfUR4EfJtHGN3J7W4XYJVLryaRTFU";
		private readonly string apiSecret = "sandbox-JuuBsQV3D0HDHXEONqr7srypCpSC1AbE";
		private readonly string _baseUrl = "https://sandbox-api.iyzipay.com";

		// daha sonrasında parametre olarak product'ı da almamız lazım.
		public async Task<ProcessPaymentCommandResponse> ProcessPaymentAsync(ProcessPaymentCommand request)
		{
			Iyzipay.Options options = new Iyzipay.Options()
			{
				ApiKey = apiKey,
				SecretKey = apiSecret,
				BaseUrl = _baseUrl,
			};


			// Alıcı (buyer) bilgileri
			var buyer = new Buyer
			{
				//Id = request.BuyerId,
				Id = "1",
				Name = request.BuyerName,
				Surname = request.BuyerSurname,
				Email = request.BuyerEmail,
				GsmNumber = request.BuyerGsmNumber,
				IdentityNumber = request.BuyerIdentityNumber,
				//Ip = request.BuyerIp,
				Ip = "85.34.78.112",
                RegistrationAddress = request.BillingAddress,
				City = request.BuyerCity,
				Country = request.BuyerCountry,
				ZipCode = request.BuyerZipCode
			};

			var address = new Iyzipay.Model.Address
			{
				ContactName = buyer.Name + "" + buyer.Surname,
				ZipCode = request.BuyerZipCode,
				Country = request.BuyerCountry,
				City = request.BuyerCity,
				Description = "adressss",
			};

			var basketItem = new List<BasketItem>
			{
				new BasketItem
				{
					Id = "item1id",
					Name = "item1name",
					Category1 = "item1category",
					//Price = request.Price.ToString(),
					Price = request.Price.ToString("F2", CultureInfo.InvariantCulture),
					ItemType = BasketItemType.PHYSICAL.ToString()
					
				}
			};

			var checkoutPaymentRequest = new CreateCheckoutFormInitializeRequest()
			{
				Locale = Locale.TR.ToString(),
				ConversationId = Guid.NewGuid().ToString(),
				Currency = Currency.TRY.ToString(),
				Price = request.Price.ToString("F2", CultureInfo.InvariantCulture),
				PaidPrice = request.PaidPrice.ToString("F2", CultureInfo.InvariantCulture),
				//Price = request.Price.ToString(),
				//PaidPrice = request.PaidPrice.ToString(),
				BasketId = "B67832",
				/*BasketId = Guid.NewGuid().ToString(),*/       // ??
				Buyer = buyer,
				BasketItems = basketItem,
				BillingAddress = address,
				ShippingAddress = address,
				PaymentGroup = PaymentGroup.PRODUCT.ToString(),  // Ürün satın alımı için yapılan ödeme.
				EnabledInstallments = new List<int> { 1 },      // Taksitsiz işlem
				CallbackUrl = "https://localhost:7053/Payment/PaymentCallback",  // Callback URL		
				//ForceThreeDS = 1,				
			};

            // 5528 7900 0000 0008

            var payment = await CheckoutFormInitialize.Create(checkoutPaymentRequest, options);


			// Ödeme sonucunu döndürüyoruz
			if (payment.Status == "success")
			{
				return new ProcessPaymentCommandResponse
				{
					IsSuccess = true,
					IyzicoCheckoutFormContent = payment.CheckoutFormContent,
					PaymentId = checkoutPaymentRequest.ConversationId,
					Message = payment.ErrorMessage,
				};
			}
			else
			{
				return new ProcessPaymentCommandResponse
				{
					IsSuccess = false,
					PaymentId = null,
					Message = $"Ödeme işlemi başarısız. Hata : {payment.ErrorGroup} ++++++ {payment.ErrorMessage} ",
				};
			}

		}
	}
}

/*

{
  "buyerId": "8a154610-097a-4de3-b6ff-38f4c14bc173",
  "buyerName": "Semih",
  "buyerSurname": "Yazar",
  "buyerEmail": "semih.yazar@gmail.com",
  "buyerGsmNumber": "+905551234567",
  "buyerIdentityNumber": "214097567180",
  "buyerIp": "192.168.1.1",
  "buyerCity": "Istanbul",
  "buyerCountry": "Turkey",
  "buyerAddress": "123 Main St, Kadikoy, Istanbul",
  "buyerZipCode": "34732",
  "shippingAddress": "123 Main St, Kadikoy, Istanbul",
  "billingAddress": "123 Main St, Kadikoy, Istanbul",
  "paymentId": "abc123xyz456",
  "price": 100.00,
  "paidPrice": 100.00,
  "callbackUrl": "https://yourcallbackurl.com"
}


*/