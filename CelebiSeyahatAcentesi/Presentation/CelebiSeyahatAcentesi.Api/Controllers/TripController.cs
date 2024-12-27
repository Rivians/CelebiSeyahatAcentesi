using CelebiSeyahat.Application.Features.TripFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CelebiSeyahat.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TripController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("GetFilteredTrips")]
        public async Task<IActionResult> GetFilteredTrips([FromBody] GetFilteredTripsQuery query)
        {
            var trips = await _mediator.Send(query);
            return Ok(trips);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTripById(string id)
        {
            var trip = await _mediator.Send(new GetTripByIdQuery(id));
            return Ok(trip);
        }

	}
}
