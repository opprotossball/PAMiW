using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using P03Travel.Shared;
using P03Travel.Shared.Services.FlightService;
using P03Travel.Shared.Travels;
using P04WeatherForecastAPI.Client.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace P04WeatherForecastAPI.Client.Services
{
    internal class FlightService : IFlightService
    {
        private readonly HttpClient _httpClient;
        private readonly AppSettings _appSettings;

        public FlightService(HttpClient httpClient, IOptions<AppSettings> appSettings)
        {
            _httpClient = httpClient;
            _appSettings = appSettings.Value;
        }

        public async Task<ServiceResponse<Flight>> AddFlightAsync(Flight flight)
        {
            var response = await _httpClient.PostAsJsonAsync(_appSettings.FlightAPI.FlightEndpoint, flight);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Flight>>();
            return result;
        }

        public async Task<ServiceResponse<bool>> DeleteFlightAsync(int id)
        {
            try
            {
                string endpoint = string.Format(_appSettings.FlightAPI.GetByIdEndpoint, id);
                var response = await _httpClient.DeleteAsync(endpoint);
                var json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ServiceResponse<bool>>(json);
                return result;
            }
            catch (Exception ex)
            {
                return new ServiceResponse<bool>()
                {
                    Data = false,
                    Success = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<ServiceResponse<Flight>> GetFlightAsync(int id)
        {
            try
            {
                string endpoint = string.Format(_appSettings.FlightAPI.GetByIdEndpoint, id);
                var response = await _httpClient.GetAsync(endpoint);
                var json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ServiceResponse<Flight>>(json);
                return result;
            }
            catch (Exception ex) 
            {
                return new ServiceResponse<Flight>()
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<ServiceResponse<List<Flight>>> GetFlightsAsync(int num)
        {
            string endpoint = string.Format(_appSettings.FlightAPI.FirstNFlightsEndpoint, num);
            var response = await _httpClient.GetAsync(endpoint);
            if (!response.IsSuccessStatusCode)
            {
                Debug.WriteLine($"Request failed with status code: {response.StatusCode} {response.RequestMessage.RequestUri}");
                return new ServiceResponse<List<Flight>>()
                {
                    Success = false
                };
            }
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<List<Flight>>>(json);
            if (result != null)
            {
                return result;
            }
            return new ServiceResponse<List<Flight>>()
            {
                Success = false
            };
        }

        public async Task<ServiceResponse<List<Flight>>> GetFromToAsync(string from, string to)
        {
            string endpoint = string.Format(_appSettings.FlightAPI.RelationEndpoint, from, to);
            var response = await _httpClient.GetAsync(endpoint);
            if (!response.IsSuccessStatusCode)
            {
                Debug.WriteLine($"Request failed with status code: {response.StatusCode} {response.RequestMessage.RequestUri}");
                return new ServiceResponse<List<Flight>>()
                {
                    Success = false
                };
            }
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<List<Flight>>>(json);
            if (result != null)
            {
                return result;
            }
            return new ServiceResponse<List<Flight>>()
            {
                Success = false
            };
        }

        public async Task<ServiceResponse<Flight>> ModifyFlightAsync(Flight flight)
        {
            throw new NotImplementedException();
        }
    }
}
