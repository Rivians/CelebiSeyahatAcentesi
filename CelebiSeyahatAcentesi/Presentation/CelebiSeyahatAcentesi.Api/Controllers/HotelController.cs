using CelebiSeyahat.Application.Features.HotelFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CelebiSeyahat.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IMediator _mediator;
        public HotelController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("GetFilteredHotels")]
        public async Task<IActionResult> GetFilteredHotels([FromQuery] GetFilteredHotelsQuery query)
        {
            if (string.IsNullOrEmpty(query.ToString())) { return BadRequest("The term field is required."); }

            var hotelList = await _mediator.Send(query);
            if (hotelList != null)
            {
                return Ok(hotelList);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("GetHotelNamesForAjax")]
        public async Task<IActionResult> GetHotelNamesForAjax([FromQuery] GetHotelNamesForAjaxQuery query)
        {
            var hotelNames = await _mediator.Send(query);
            if (hotelNames != null)
            {
                return Ok(hotelNames);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("GetHotelNames")]
        public async Task<IActionResult> GetHotelNames()
        {
            var query = new GetHotelNamesQuery();
            var hotelNames = await _mediator.Send(query);
            if (hotelNames != null)
            {
                return Ok(hotelNames);
            }
            else
            {
                return BadRequest();
            }
        }

        //[HttpGet("GetHotelNamesTest")]
        //public IActionResult GetHotelNames(string query)
        //{
        //    var hotelNames = new List<string> { "Otel A", "Otel B", "Otel C", "Otel D" };
        //    var filteredHotels = hotelNames
        //        .Where(h => h.Contains(query, StringComparison.OrdinalIgnoreCase))
        //        .ToList();
        //    return Ok(filteredHotels);
        //}

    }
}
