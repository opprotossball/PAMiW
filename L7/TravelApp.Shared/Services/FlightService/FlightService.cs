﻿using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using P03Travel.Shared;
using P03Travel.Shared.Travels;
using System;
using System.Diagnostics;
using System.Net.Http.Json;
using P03Travel.Shared.Configuration;

namespace P03Travel.Shared.Services.FlightService
{
	public class FlightService : IFlightService
    {
        private readonly HttpClient _httpClient;
        private readonly AppSettings _appSettings;

        public FlightService(HttpClient httpClient, AppSettings appSettings)
        {
            _httpClient = httpClient;
            _appSettings = appSettings;
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
            try
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
            catch (Exception ex)
            {
                return new ServiceResponse<List<Flight>>()
                {
                    Success = false,
                    Message = ex.Message
                };
            }
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
			var response = await _httpClient.PutAsJsonAsync(_appSettings.FlightAPI.FlightEndpoint, flight);
			var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Flight>>();
			return result;
		}

		public async Task<ServiceResponse<List<Flight>>> SearchFlightsAsync(string searchTerm, int page, int pageSize)
		{
			string endpoint = string.Format(_appSettings.FlightAPI.SearchEndpoint, searchTerm, page, pageSize);
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

		public async Task<ServiceResponse<List<Flight>>> GetFlightsAsync(int page, int pageSize)
		{
			string endpoint = string.Format(_appSettings.FlightAPI.ListEndpoint, page, pageSize);
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
