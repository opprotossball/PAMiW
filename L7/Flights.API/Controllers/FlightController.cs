using Microsoft.AspNetCore.Mvc;
using P03Travel.Shared;
using P03Travel.Shared.Travels;
using P03Travel.Shared.Services.FlightService;

namespace P02Travel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : Controller
    {
        private readonly IFlightService _flightService;

        public FlightController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        [HttpGet("first")]
        public async Task<ActionResult<ServiceResponse<List<Flight>>>> GetFlights([FromQuery] int num)
        {
            var result = await _flightService.GetFlightsAsync(num);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(500, $"Internal server error: {result.Message}");
            }
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<Flight>>> GetFlight([FromQuery] int id)
        {
            var result = await _flightService.GetFlightAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(500, $"Internal server error: {result.Message}");
            }
        }

        [HttpGet("relation")]
        public async Task<ActionResult<ServiceResponse<List<Flight>>>> GetRelationFlights([FromQuery] string from, string to)
        {
            var result = await _flightService.GetFromToAsync(from, to);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(500, $"Internal server error: {result.Message}");
            }
        }

        [HttpGet("search")]
        public async Task<ActionResult<ServiceResponse<List<Flight>>>> SearchFlightsAsync([FromQuery] string search, int page, int pagesize)
        {
            var result = await _flightService.SearchFlightsAsync(search, page, pagesize);
			if (result.Success)
			{
				return Ok(result);
			}
			else
			{
				return StatusCode(500, $"Internal server error: {result.Message}");
			}
		}

		[HttpGet("list")]
		public async Task<ActionResult<ServiceResponse<List<Flight>>>> FlightsListAsync([FromQuery] int page, int pagesize)
		{
			var result = await _flightService.GetFlightsAsync(page, pagesize);
			if (result.Success)
			{
				return Ok(result);
			}
			else
			{
				return StatusCode(500, $"Internal server error: {result.Message}");
			}
		}

		[HttpDelete]
        public async Task<IActionResult> DeleteFlight([FromQuery] int id)
        {
            var result = await _flightService.DeleteFlightAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(500, $"Internal server error: {result.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddFlightAsync([FromBody] Flight flight)
        {
            var result = await _flightService.AddFlightAsync(flight);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(500, $"Internal server error: {result.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> ModifyFlight([FromBody] Flight flight)
        {
            var result = await _flightService.ModifyFlightAsync(flight);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(500, $"Internal server error: {result.Message}");
            }
        }
    }
}
