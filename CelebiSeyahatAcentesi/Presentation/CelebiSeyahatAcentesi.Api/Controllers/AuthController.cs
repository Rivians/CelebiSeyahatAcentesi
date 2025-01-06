using CelebiSeyahat.Application.Features.AuthFeatures.Commands.Login;
using CelebiSeyahat.Application.Features.AuthFeatures.Commands.Register;
using CelebiSeyahat.Application.Features.AuthFeatures.Commands.Role;
using CelebiSeyahat.Application.Features.AuthFeatures.Queriess;
using CelebiSeyahat.Application.Features.EmailFeatures;
using CelebiSeyehat.Dto.AppUser;
using CelebiSeyehat.Dto.Customer;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
            await _mediator.Send(command, cancellationToken);

            var emailCommand = new SendEmailCommand()
            {
                Subject = "Kayıt İşlemi",
                //Body = $"<h1>Aramıza hoş geldin {command.Name}!</h1><p>Sitemize kayıt olma işleminiz başarılı bir şekilde tamamlanmıştır. Teşekkür ederiz. Keyifli yolculuklar dileriz.</p>",
                Body = $"<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <title>Hoş Geldiniz!</title>\r\n    <style>\r\n        body {{\r\n            font-family: Arial, sans-serif;\r\n            background-color: #f4f4f4;\r\n            margin: 0;\r\n            padding: 0;\r\n        }}\r\n        .container {{\r\n            width: 100%;\r\n            max-width: 600px;\r\n            margin: 0 auto;\r\n            background-color: #ffffff;\r\n            box-shadow: 0 2px 4px rgba(0,0,0,0.1);\r\n            border-radius: 8px;\r\n            overflow: hidden;\r\n        }}\r\n        .header {{\r\n            background-color: #4CAF50;\r\n            color: #ffffff;\r\n            padding: 20px;\r\n            text-align: center;\r\n        }}\r\n        .header h1 {{\r\n            margin: 0;\r\n        }}\r\n        .content {{\r\n            padding: 20px;\r\n            text-align: center;\r\n        }}\r\n        .content h2 {{\r\n            color: #333333;\r\n        }}\r\n        .content p {{\r\n            color: #555555;\r\n        }}\r\n        .content a {{\r\n            display: inline-block;\r\n            margin-top: 20px;\r\n            padding: 10px 20px;\r\n            background-color: #4CAF50;\r\n            color: #ffffff;\r\n            text-decoration: none;\r\n            border-radius: 4px;\r\n        }}\r\n        .footer {{\r\n            background-color: #f4f4f4;\r\n            color: #888888;\r\n            padding: 20px;\r\n            text-align: center;\r\n            font-size: 12px;\r\n        }}\r\n    </style>\r\n</head>\r\n<body>\r\n    <div class=\"container\">\r\n        <div class=\"header\">\r\n            <h1>Aramıza Hoş Geldiniz!</h1>\r\n        </div>\r\n        <div class=\"content\">\r\n            <h2>Merhaba, {command.Name}!</h2>\r\n            <p>Sitemize kaydolduğunuz için teşekkür ederiz. Artık avantajlardan ve fırsatlardan yararlanabilirsiniz.</p>\r\n            <a href=\"https://localhost:7053/Home/Index\">Sitemizi Ziyaret Edin</a>\r\n        </div>\r\n        <div class=\"footer\">\r\n            <p>Bu e-posta otomatik olarak oluşturulmuştur, lütfen cevap vermeyin.</p>\r\n            <p>© 2025 Your Company. Tüm hakları saklıdır.</p>\r\n        </div>\r\n    </div>\r\n</body>\r\n</html>\r\n",
                ToEmail = command.Email

            };
            await _mediator.Send(emailCommand);
            return Ok();
        }

        //[Authorize]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("GetAuthenticatedUser")]
        public async Task<IActionResult> GetAuthenticatedUser()
        {
            var user = await _mediator.Send(new GetAuthenticatedUserQuery());

            if (user == null || user.AppUser == null)
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

