using CelebiSeyehat.Dto.Hotel;
using CelebiSeyehat.Dto.Payment;
using CelebiSeyehat.Dto.Trip;
using CelebiSeyehat.UI.ViewModels.Payment;
using CelebiSeyehat.UI.ViewModels.Reservation;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Globalization;
using System.Net.Http.Headers;
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
		public async Task<IActionResult> Index(/*string data*/)
		{
			var hotelRezervationJson = HttpContext.Session.GetString("HotelRezervation");
			var hotelRezervation = JsonConvert.DeserializeObject<HotelReservationViewModel>(hotelRezervationJson);

			//var tripRezervationJson = HttpContext.Session.GetString("TripRezervation");
			//var tripRezervation = JsonConvert.DeserializeObject<TransportationReservationViewModel>(tripRezervationJson);

			var paymentRequest = new ProcessPaymentCommandDto()
			{
				BuyerId = hotelRezervation.AppUser.Customer.Id,
				BuyerName = hotelRezervation.AppUser.Customer.FirstName,
				BuyerSurname = hotelRezervation.AppUser.Customer.LastName,
				BuyerEmail = hotelRezervation.AppUser.Customer.Email,
				BuyerGsmNumber = hotelRezervation.AppUser.Customer.PhoneNumber,
				BuyerCity = "Istanbul",
				BuyerCountry = "Turkiye",
				BuyerIdentityNumber = hotelRezervation.Guests[0].TcNo,
				BuyerZipCode = "34760",
				BillingAddress = "billging addderesss",
				BuyerAddress = "buyerr adressss",
				ShippingAddress = "shipppinggg adress",
				BuyerIp = HttpContext.Connection.RemoteIpAddress.ToString(),
				PaymentId = Guid.NewGuid().ToString(),
				//Price = (decimal)(hotelRezervation * reservationResults.PassengerCount),
				Price = 1500,
				//PaidPrice = (decimal)(reservationResults.Trip.TicketPrice * reservationResults.PassengerCount),
				PaidPrice = 1500,
				CallbackUrl = "",
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

        [HttpPost]
        public async Task<IActionResult> PaymentCallback([FromForm] string token)
        {
            var client = _httpClientFactory.CreateClient();

            Iyzipay.Options options = new Iyzipay.Options()
            {
                ApiKey = "sandbox-ea0DfUR4EfJtHGN3J7W4XYJVLryaRTFU",
                SecretKey = "sandbox-JuuBsQV3D0HDHXEONqr7srypCpSC1AbE",
                BaseUrl = "https://sandbox-api.iyzipay.com"
            };

			var request = new RetrieveCheckoutFormRequest
			{
				Token = token,
			};

            var checkoutForm = CheckoutForm.Retrieve(request, options);

			if(checkoutForm.Result.PaymentStatus == "SUCCESS")
            {
				// Ödeme başarılı
				var paymentDetails = new PaymentDto
				{
					Id = checkoutForm.Result.PaymentId,
					PaymentStatus = checkoutForm.Result.PaymentStatus,
                    Amount = checkoutForm.Result.PaidPrice,
                    PaymentDate = DateTime.Now
				};

                return RedirectToAction("Callback", new { success = true, paymentDetails = JsonConvert.SerializeObject(paymentDetails) });
            }
			else
			{
                // Ödeme başarısız
                return RedirectToAction("Callback", new { success = false, error = checkoutForm.Result.ErrorMessage });
            }
        }


        [HttpGet]
		public IActionResult Callback(string paymentDetails, bool success, string message = null)
		{
            var paymentDetailsDto = JsonConvert.DeserializeObject<PaymentDto>(paymentDetails);

            var viewModel = new PaymentResultViewModel
			{
				IsSuccess = success,
				ErrorCode = message
			};

			return View(viewModel);
		}
	}
}
