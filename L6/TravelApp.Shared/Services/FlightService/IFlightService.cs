using P03Travel.Shared.Travels;

namespace P03Travel.Shared.Services.FlightService
{
    public interface IFlightService
    {
        public Task<ServiceResponse<List<Flight>>> GetFlightsAsync(int num);
		public Task<ServiceResponse<List<Flight>>> GetFlightsAsync(int page, int pageSize);
		public Task<ServiceResponse<bool>> DeleteFlightAsync(int id);
        public Task<ServiceResponse<Flight>> ModifyFlightAsync(Flight flight);
        public Task<ServiceResponse<Flight>> AddFlightAsync(Flight flight);
        public Task<ServiceResponse<Flight>> GetFlightAsync(int id);
        public Task<ServiceResponse<List<Flight>>> GetFromToAsync(string from, string to);
        public Task<ServiceResponse<List<Flight>>> SearchFlightsAsync(string searchTerm, int page, int pageSize);
    }
}
