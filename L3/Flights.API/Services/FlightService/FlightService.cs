using Microsoft.AspNetCore.Mvc;
using P03Travel.Shared;
using P03Travel.Shared.Services.FlightService;
using P03Travel.Shared.Travels;
using P05Travel.DataSeeder;
using System;

namespace P02Travel.API.Services.FlightService
{ 
    public class FlightService : IFlightService
    {
        public async Task<ServiceResponse<Flight>> GetFlightAsync(int id)
        {
            try
            {
                Flight flight = FlightSeeder.GenerateFlightData(1)[0];
                flight.Id = id;
                return new ServiceResponse<Flight>()
                {
                    Data = flight,
                    Message = "Ok",
                    Success = true
                };
            }
            catch (Exception)
            {
                return new ServiceResponse<Flight>()
                {
                    Data = null,
                    Message = "Problem with dataseeder",
                    Success = false
                };
            }
        }

        public async Task<ServiceResponse<Flight>> AddFlightAsync(Flight flight)
        {
            return new ServiceResponse<Flight>()
            {
                Data = flight,
                Message = "Flight added succesfully",
                Success = true
            };
        }

        public async Task<ServiceResponse<List<Flight>>> GetFlightsAsync(int num)
        {
            try
            {
                List<Flight> flights = FlightSeeder.GenerateFlightData(num);
                return new ServiceResponse<List<Flight>>()
                {
                    Data = flights,
                    Message = "Ok",
                    Success = true
                };
            }
            catch (Exception)
            {
                return new ServiceResponse<List<Flight>>()
                {
                    Data = null,
                    Message = "Problem with dataseeder",
                    Success = false
                };
            }
        }

        public async Task<ServiceResponse<Flight>> ModifyFlightAsync(int id, Flight flight)
        {
            return new ServiceResponse<Flight>() { Data = flight, Message = "Filght modified successfully", Success = true };
        }

        public async Task<ServiceResponse<Flight>> DeleteFlightAsync(int id)
        {
            try
            {
                Flight flight = FlightSeeder.GenerateFlightData(1)[0];
                flight.Id = id;
                return new ServiceResponse<Flight>()
                {
                    Data = flight,
                    Message = "Flight deleted succesfully",
                    Success = true
                };
            }
            catch (Exception)
            {
                return new ServiceResponse<Flight>()
                {
                    Data = null,
                    Message = "Problem with dataseeder",
                    Success = false
                };
            }
        }

        public async Task<ServiceResponse<List<Flight>>> GetFromToAsync(string from, string to)
        {
            Random random = new Random();
            try
            {
                List<Flight> flights = FlightSeeder.GenerateFlightData(random.Next(0, 7));
                foreach (var flight in flights) 
                {
                    flight.From = from;
                    flight.To = to;
                }
                return new ServiceResponse<List<Flight>>()
                {
                    Data = flights,
                    Message = "Ok",
                    Success = true
                };
            }
            catch (Exception)
            {
                return new ServiceResponse<List<Flight>>()
                {
                    Data = null,
                    Message = "Problem with dataseeder",
                    Success = false
                };
            }
        }
    }
}
