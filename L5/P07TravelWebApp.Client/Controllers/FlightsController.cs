using Microsoft.AspNetCore.Mvc;
using P03Travel.Shared.Services.FlightService;
using P03Travel.Shared.Travels;

namespace P07TravelWebApp.Client.Controllers
{
    public class FlightsController : Controller
    {
      
        private readonly IFlightService _flightService;

        public FlightsController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        public async Task<IActionResult> Index()
        {
            var flights = await _flightService.GetFlightsAsync(10);
            if (flights != null) 
            {
                return View(flights.Data.AsEnumerable());
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var product = await _flightService.GetFlightAsync((int)id);

            if (product.Data == null)
            {
                return NotFound();
            }
            return View(product.Data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Airlines,From,To,Price,DepartureTime")] Flight flight)
        {

            if (ModelState.IsValid)
            {
                await _flightService.AddFlightAsync(flight);
                return RedirectToAction(nameof(Index));
            }
            return View(flight);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var flight = await _flightService.GetFlightAsync((int)id);
            if (flight.Data == null)
            {
                return NotFound();
            }
            return View(flight.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Airlines,From,To,Price,DepartureTime")] Flight flight)
        {

            if (id != flight.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var productResult = await _flightService.ModifyFlightAsync(flight);
                }
                catch (Exception)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(flight);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var flight = await _flightService.GetFlightAsync((int)id);
            if (flight == null)
            {
                return NotFound();
            }
            return View(flight.Data);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _flightService.DeleteFlightAsync((int)id);
            if (product.Success)
                return RedirectToAction(nameof(Index));
            else
                return NotFound();
        }
    }
}

