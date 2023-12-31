﻿using Microsoft.AspNetCore.Mvc;
using P03Travel.Shared;
using P03Travel.Shared.Travels;
using P03Travel.Shared.Services.FlightService;

namespace Travel.API.Controllers
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

        [HttpGet("{id:int}")]
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

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteFlight([FromRoute] int id)
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

        [HttpPut("{id:int}")]
        public async Task<IActionResult> ModifyFlight([FromRoute] int id, [FromBody] Flight flight)
        {
            var result = await _flightService.ModifyFlightAsync(id, flight);
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
