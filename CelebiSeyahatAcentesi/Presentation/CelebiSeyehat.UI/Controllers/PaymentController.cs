using CelebiSeyehat.Dto.Payment;
using CelebiSeyehat.Dto.Trip;
using CelebiSeyehat.UI.ViewModels.Payment;
using CelebiSeyehat.UI.ViewModels.Reservation;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CelebiSeyehat.UI.Controllers
{
	public class PaymentController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public PaymentController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[HttpGet]
		public async Task<IActionResult> Index(string data)
		{
			var base64DecodedList = Convert.FromBase64String(data);
			var jsonData = Encoding.UTF8.GetString(base64DecodedList);
			var reservationResults = JsonConvert.DeserializeObject<TransportationReservationViewModel>(jsonData);

			var paymentRequest = new ProcessPaymentCommandDto()
			{
				BuyerId = reservationResults.AppUser.Customer.Id,
				BuyerName = reservationResults.AppUser.Customer.FirstName,
				BuyerSurname = reservationResults.AppUser.Customer.LastName,
				BuyerEmail = reservationResults.AppUser.Customer.Email,
				BuyerGsmNumber = reservationResults.AppUser.Customer.PhoneNumber,
				BuyerCity = "Istanbul",
				BuyerCountry = "Turkiye",
				BuyerIdentityNumber = reservationResults.Passengers[0].PassengerTcNo,
				BuyerZipCode = "34760",
				BillingAddress = "billging addderesss",
				BuyerAddress = "buyerr adressss",
				ShippingAddress = "shipppinggg adress",
				BuyerIp = HttpContext.Connection.RemoteIpAddress.ToString(),
				PaymentId = Guid.NewGuid().ToString(),
				Price = (decimal)(reservationResults.Trip.TicketPrice * reservationResults.PassengerCount),
				PaidPrice = (decimal)(reservationResults.Trip.TicketPrice * reservationResults.PassengerCount),
				CallbackUrl = "https://yourcallbackurl.com",
			};

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.PostAsJsonAsync("https://localhost:7196/api/Payment/ProcessPayment", paymentRequest);

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonPayment = await responseMessage.Content.ReadAsStringAsync();
				var paymentResponse = JsonConvert.DeserializeObject<ProcessPaymentCommandResponseDto>(jsonPayment);
				if (paymentResponse.IsSuccess)
				{
					ViewBag.PaymentFormContent = paymentResponse.IyzicoCheckoutFormContent;
					return View();
				}
				else
				{
					return BadRequest(paymentResponse.Message);
				}
			}

			return View();
		}

        //[HttpPost]
        //public IActionResult PaymentCallback(ProcessPaymentCommandResponseDto response)
        //{
        //	if (response.IsSuccess)
        //	{
        //		// Ödeme başarılı, kullanıcıya başarı bilgisi gösterilir.
        //		return RedirectToAction("Callback", new { success = true });
        //	}
        //	else
        //	{
        //		// Ödeme başarısız, hata bilgisi kullanıcıya gösterilir.
        //		return RedirectToAction("Callback", new { success = false, message = response.Message });
        //	}
        //}

        [HttpPost]
        public async Task<IActionResult> PaymentCallback([FromForm] string token, [FromForm] string paymentId)
        {
            // Doğrulama isteği hazırlama
            var client = _httpClientFactory.CreateClient();
            var verifyRequest = new
            {
                PaymentId = paymentId,
                Token = token
            };

            var response = await client.PostAsJsonAsync("https://sandbox-api.iyzipay.com/payment/iyzipos/checkoutform/ecom/detail", verifyRequest);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var verificationResult = JsonConvert.DeserializeObject<ProcessPaymentCommandResponseDto>(json);

				if (verificationResult.IsSuccess)
				{
					// Ödeme başarılı
					return RedirectToAction("Callback", new { success = true });
				}
				else
				{
					return RedirectToAction("CallBack", new { success = "false" , error = $"{verificationResult.Message}"});
				}
            }
			return View();

            // Ödeme başarısız
		
            //return RedirectToAction("Callback", new { success = false, error = $"{verifyRequest.}" });
        }


        [HttpGet]
		public IActionResult Callback(bool success, string message = null)
		{
			var viewModel = new PaymentResultViewModel
			{
				IsSuccess = success,
				ErrorCode = message
			};

			return View(viewModel);
		}
	}
}
