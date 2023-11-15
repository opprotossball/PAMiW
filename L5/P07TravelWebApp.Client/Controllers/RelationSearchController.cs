using Microsoft.AspNetCore.Mvc;
using P03Travel.Shared.Services.FlightService;
using P07TravelWebApp.Client.Models;

namespace P07TravelWebApp.Client.Controllers
{
    public class RelationSearchController : Controller
    {
        private readonly IFlightService _flightService;

        public RelationSearchController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new FlightSearchModel());
        }

        [HttpPost]
        public async Task<IActionResult> RelationSearch(FlightSearchModel model)
        {
            var flights = await _flightService.GetFromToAsync(model.DepartureAirport, model.ArrivalAirport);
            if (flights == null)
            {
                return View();
            }
            return View(flights.Data.AsEnumerable());
        }
    }
}
