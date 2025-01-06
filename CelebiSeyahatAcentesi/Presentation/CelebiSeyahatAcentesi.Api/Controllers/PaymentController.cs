using CelebiSeyahat.Application.Features.PaymentFeatures.Commands;
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
	}
}
