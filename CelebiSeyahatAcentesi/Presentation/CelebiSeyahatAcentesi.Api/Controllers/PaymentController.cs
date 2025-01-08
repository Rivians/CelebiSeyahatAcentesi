using CelebiSeyahat.Application.Features.PaymentFeatures.Commands;
using Iyzipay.Model;
using Iyzipay.Request;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CelebiSeyahat.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PaymentController : ControllerBase
	{
		private readonly IMediator _mediator;
		public PaymentController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost("ProcessPayment")]
		public async Task<IActionResult> ProcessPayment([FromBody] ProcessPaymentCommand command)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var result = await _mediator.Send(command);

			if (result.IsSuccess)
			{
				return Ok(result);
			}

			return BadRequest(new
			{
				message = "Ödeme başarısız!",
				error = result.Message
			});
		}

        [HttpPost("PaymentCallback")]
        public async Task<IActionResult> PaymentCallback([FromBody] dynamic data)
        {
            //var token = form["token"];
            //string token = data?.Token;
            string token = data.Token;

            Iyzipay.Options options = new Iyzipay.Options()
            {
                ApiKey = "sandbox-ea0DfUR4EfJtHGN3J7W4XYJVLryaRTFU",
                SecretKey = "sandbox-JuuBsQV3D0HDHXEONqr7srypCpSC1AbE",
                BaseUrl = "https://sandbox-api.iyzipay.com"
            };

            var request = new RetrieveCheckoutFormRequest
            {
                Token = token
            };

            var checkoutForm = CheckoutForm.Retrieve(request, options);

            if (checkoutForm.Status.ToString() == "success")
            {
                // Ödeme başarılı
                return Ok("Ödeme başarılı");
            }
            else
            {
                // Ödeme başarısız
                return BadRequest("Ödeme başarısız");
            }
        }

    }
}
