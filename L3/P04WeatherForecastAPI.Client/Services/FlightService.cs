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

        public Task<ServiceResponse<Flight>> AddFlightAsync(Flight flight)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<Flight>> DeleteFlightAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<Flight>> GetFlightAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<Flight>>> GetFlightsAsync(int num)
        {
            string endpoint = string.Format(_appSettings.FlightAPI.FirstNFlightsEndpoint, num);
            Debug.WriteLine(endpoint);
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

        public Task<ServiceResponse<Flight>> ModifyFlightAsync(int id, Flight flight)
        {
            throw new NotImplementedException();
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
    }
}
