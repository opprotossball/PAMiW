using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using P03Travel.Shared.Travels;

namespace P03Travel.Shared.Services.FlightService
{
    public interface IFlightService
    {
        public Task<ServiceResponse<List<Flight>>> GetFlightsAsync(int num);
        public Task<ServiceResponse<Flight>> DeleteFlightAsync(int id);
        public Task<ServiceResponse<Flight>> ModifyFlightAsync(int id, Flight flight);
        public Task<ServiceResponse<Flight>> AddFlightAsync(Flight flight);
        public Task<ServiceResponse<Flight>> GetFlightAsync(int id);
        public Task<ServiceResponse<List<Flight>>> GetFromToAsync(string from, string to);
    }
}
