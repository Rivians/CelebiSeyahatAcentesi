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


        [HttpPost("GetFilteredHotels")]
        public async Task<IActionResult> GetFilteredHotels([FromBody] GetFilteredHotelsQuery query)
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

		[HttpGet("GetHotelFeatures")]
		public async Task<IActionResult> GetHotelFeatures()
		{
			var query = new GetHotelFeaturesQuery();
			var hotelFeatures = await _mediator.Send(query);
			if (hotelFeatures != null)
			{
				return Ok(hotelFeatures);
			}
			else
			{
				return BadRequest();
			}
		}

		[HttpGet("GetHotelPensionTypes")]
		public async Task<IActionResult> GetHotelPensionTypes()
		{
			var query = new GetHotelPensionTypesQuery();
			var pensionTypes = await _mediator.Send(query);

			if (pensionTypes != null)
			{
				return Ok(pensionTypes);
			}
			else
			{
				return BadRequest();
			}
		}

		[HttpGet("GetHotelById/{id}")]
        public async Task<IActionResult> GetHotelById(string id)
        {
            var query = new GetHotelByIdQuery(id);
            var response = await _mediator.Send(query);
            if(response != null)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest();
            }
        }

		[HttpGet("GetHotelReservationByRoomId/{id}")]
		public async Task<IActionResult> GetHotelReservationByRoomId(string id)
		{
			var query = new GetHotelReservationByHotelRoomIdQuery(id);
			var response = await _mediator.Send(query);
			if (response != null)
			{
				return Ok(response);
			}
			else
			{
				return BadRequest();
			}
		}

	}
}
