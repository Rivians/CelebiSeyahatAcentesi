using CelebiSeyahat.Application.Features.CustomerFeatures.Queries;
using CelebiSeyahat.Application.Features.EmailFeatures;
using CelebiSeyahat.Application.Features.NotificationFeatures.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CelebiSeyahat.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmailController : ControllerBase
	{
		private readonly IMediator _mediator;
		public EmailController(IMediator mediator)
		{
			_mediator = mediator;
		}


		[HttpPost("SendEmail")]
		public async Task<IActionResult> SendEmail(SendEmailCommand command)
		{
			await _mediator.Send(command);

			var query = new GetCustomerIdByEmailQuery()
			{
				Email = command.ToEmail
			};
			var queryResponse = await _mediator.Send(query);

			var notfyCommand = new AddNotificationCommand()
			{
				CustomerId = queryResponse.Id,
				Type = "Kayıt İşlemi",
				Message = "Kayıt işleminiz başarıyla gerçekleşmiştir."
			};
			await _mediator.Send(notfyCommand);

			return Ok("Email başarıyla gönderildi.");
		}
	}
}
