using CelebiSeyahat.Application.Features.CustomerFeatures.Queries;
using CelebiSeyahat.Application.Features.TransportationCompany;
using CelebiSeyahat.Application.Features.TripFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CelebiSeyahat.Api.Controllers
{
    //[Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("GetCustomerListWithAll")]
        public async Task<IActionResult> GetCustomerListWithAll()
        {
            var query = new GetCustomerListWithAllQuery();
            var customerList = await _mediator.Send(query);

            if (customerList != null)
            {
				return Ok(customerList);
			}
            else
            {
                return BadRequest();
            }            
        }

        [HttpGet("GetTransportationCompanyListWithAll")]
        public async Task<IActionResult> GetTransportationCompanyListWithAll()
        {
            var query = new GetTransportationListWithAllQuery();
            var transportationCompanyList = await _mediator.Send(query);

            if (transportationCompanyList != null)
            {
                return Ok(transportationCompanyList);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("GetTripListWithAll")]
        public async Task<IActionResult> GetTripListWithAll()
        {
            var query = new GetTripListWithAllQuery();
            var tripList = await _mediator.Send(query);

            if (tripList != null)
            {
                return Ok(tripList);
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
