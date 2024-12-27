using CelebiSeyahat.Application.Features.AuthFeatures.Commands.Login;
using CelebiSeyahat.Application.Features.AuthFeatures.Commands.Register;
using CelebiSeyahat.Application.Features.AuthFeatures.Commands.Role;
using CelebiSeyahat.Application.Features.AuthFeatures.Queriess;
using CelebiSeyehat.Dto.AppUser;
using CelebiSeyehat.Dto.Customer;
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

        [HttpGet("GetAuthenticatedUser")]
        public async Task<IActionResult> GetAuthenticatedUser()
        {
            var user = await _mediator.Send(new GetAuthenticatedUserQuery());

            if(user == null || user.AppUser == null)
            {
                return NotFound("Kullanıcı bulunamadı.");
            }

            var userDto = new AppUserDto
            {
                Id = user.AppUser.Id,
                Name = user.AppUser.Name,
                Surname = user.AppUser.LastName,
                Email = user.AppUser.Email,
                PhoneNumber = user.AppUser.Customer.PhoneNumber,
                Customer = new CustomerDto
                {
                    Id = user.AppUser.Customer.Id,
                    FirstName = user.AppUser.Customer.FirstName,
                    LastName = user.AppUser.Customer.LastName,
                    Email = user.AppUser.Customer.Email,
                    PhoneNumber = user.AppUser.Customer.PhoneNumber,
                }
            };

            return Ok(userDto);
        }

        [HttpPost("AddRole")]
        public async Task<IActionResult> AddRole([FromBody] AddRoleCommand command)
        {
            await _mediator.Send(command);
            return Ok();   // AddRoleCommandResponse olusturulup içirisine String message prop olusturulabilir. + ve - durumlarına göre message return edilebilir !!!
        }

        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole([FromBody] AssignRoleCommand command)
        {
            try
            {
                await _mediator.Send(command);
                return Ok("Rol başarıyla atandı!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Hata oluştu : {ex.Message}");
            }            
        }
	}
}
