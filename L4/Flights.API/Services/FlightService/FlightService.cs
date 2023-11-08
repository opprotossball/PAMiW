using Microsoft.EntityFrameworkCore;
using P02Travel.API.Models;
using P03Travel.Shared;
using P03Travel.Shared.Services.FlightService;
using P03Travel.Shared.Travels;

namespace P02Travel.API.Services.FlightService
{ 
    public class FlightService : IFlightService
    {
        private readonly DataContext _dataContext;

        public FlightService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<ServiceResponse<Flight>> GetFlightAsync(int id)
        {
            try
            {
                var flights = await _dataContext.Flights
                    .Where(x => x.Id == id)
                    .ToListAsync();
                if (flights.Count == 0)
                {
                    return new ServiceResponse<Flight>()
                    {
                        Data = null,
                        Message = $"Flight with id {id} does not exist",
                        Success = false
                    };
                }
                return new ServiceResponse<Flight>()
                {
                    Data = flights.FirstOrDefault(),
                    Success = true
                };
            }
            catch (Exception)
            {
                return new ServiceResponse<Flight>()
                {
                    Data = null,
                    Message = "Cannot get flight",
                    Success = false
                };
            }
        }

        public async Task<ServiceResponse<Flight>> AddFlightAsync(Flight flight)
        {
            try
            {
                _dataContext.Flights.Add(flight);
                await _dataContext.SaveChangesAsync();
                return new ServiceResponse<Flight>() { Data = flight, Success = true };
            }
            catch (Exception)
            {
                return new ServiceResponse<Flight>()
                {
                    Data = flight,
                    Message = "Cannot create flight",
                    Success = false
                };
            };
        }

        public async Task<ServiceResponse<List<Flight>>> GetFlightsAsync(int num)
        {
            try
            {
                var flights = await _dataContext.Flights
                    .Take(num)
                    .ToListAsync();
                return new ServiceResponse<List<Flight>>()
                {
                    Data = flights,
                    Success = true
                };
            }
            catch (Exception)
            {
                return new ServiceResponse<List<Flight>>()
                {
                    Data = null,
                    Message = "Cannot get flights",
                    Success = false
                };
            }
        }

        public async Task<ServiceResponse<Flight>> ModifyFlightAsync(Flight flight)
        {
            try
            {
                var edited = new Flight() { Id = flight.Id };
                _dataContext.Flights.Attach(edited);
                edited.Airlines = flight.Airlines;
                edited.From = flight.From;
                edited.To = flight.To;
                edited.Price = flight.Price;
                edited.DepartureTime = flight.DepartureTime;
                await _dataContext.SaveChangesAsync();
                return new ServiceResponse<Flight> { Data = edited, Success = true };
            }
            catch (Exception)
            {
                return new ServiceResponse<Flight>
                {
                    Data = null,
                    Success = false,
                    Message = "Cannot update product"
                };
            }
        }

        public async Task<ServiceResponse<bool>> DeleteFlightAsync(int id)
        {
            var flight = new Flight() { Id = id };
            _dataContext.Flights.Attach(flight);
            _dataContext.Flights.Remove(flight);
            await _dataContext.SaveChangesAsync();
            return new ServiceResponse<bool>() { Data = true, Success = true };
        }

        public async Task<ServiceResponse<List<Flight>>> GetFromToAsync(string from, string to)
        {
            try
            {
                var flights = await _dataContext.Flights
                    .Where(x => x.From == from && x.To == to)
                    .ToListAsync();
                return new ServiceResponse<List<Flight>>()
                {
                    Data = flights,
                    Success = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<List<Flight>>()
                {
                    Data = null,
                    Message = $"Cannot get flights for this relation {e.Message}",
                    Success = false
                };
            }
        }
    }
}
