using CelebiSeyahat.Application.Features.AuthFeatures.Commands.Login;
using CelebiSeyahat.Application.Features.AuthFeatures.Commands.Register;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CelebiSeyahat.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // schema ????
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginCommand command, CancellationToken cancellationToken)
        {
            LoginCommandResponse response = await _mediator.Send(command, cancellationToken);
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command,cancellationToken);
            return Ok();
        }
    }
}
