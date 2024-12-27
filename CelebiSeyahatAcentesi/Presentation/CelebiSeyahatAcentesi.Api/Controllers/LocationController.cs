using CelebiSeyahat.Application.Features.LocationFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CelebiSeyahat.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LocationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetLocationList")]
        public async Task<IActionResult> GetLocationList()
        {           
            var query = await _mediator.Send(new GetLocationListQuery());
            if(query == null || !query.Any())
            {
                return NotFound("Şehirler bulunamadı.");
            }

            return Ok(query);
        }
    }
}
