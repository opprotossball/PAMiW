using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using P04WeatherForecastAPI.Client.Models;
using P03Travel.Shared.Configuration;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace P04WeatherForecastAPI.Client.Services
{
    internal class AccuWeatherService : IAccuWeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly AppSettings _appSettings;

        public AccuWeatherService(HttpClient httpClient, IOptions<AppSettings> appSettings)
        {
            _httpClient = httpClient;
            _appSettings = appSettings.Value;
        }

        public async Task<City[]> GetLocations(string locationName)
        {
            string uri = _appSettings.WeatherAPI.BaseUrl + "/" + string.Format(_appSettings.WeatherAPI.AutocompleteEndpoint, _appSettings.WeatherAPI.APIKey, locationName, _appSettings.DefaultLanguage);
            using (HttpClient client = new HttpClient())
            {
                string json = "";
                try
                {
                    var response = await client.GetAsync(uri);
                    json = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine(json);
                    Debug.WriteLine("\n");
                    City[] cities;
                    cities = JsonConvert.DeserializeObject<City[]>(json);
                    return cities;
                }
                catch (Exception ex) 
                {
                    Debug.WriteLine(ex);
                    Debug.WriteLine($"json: {json}");
                    return new City[] { };
                }
            }
        }

        public async Task<Weather> GetCurrentConditions(string cityKey)
        {
            string json = "";
            try
            {
                string uri = _appSettings.WeatherAPI.BaseUrl + "/" + string.Format(_appSettings.WeatherAPI.CurrentConditionsEndpoint, cityKey, _appSettings.WeatherAPI.APIKey, _appSettings.DefaultLanguage);
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(uri);
                    json = await response.Content.ReadAsStringAsync();
                    Weather[] weathers;
                    weathers = JsonConvert.DeserializeObject<Weather[]>(json);
                    Debug.Write(json);
                    return weathers.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                Debug.WriteLine($"json: {json}");
                return new Weather();
            }
        }

        public async Task<Weather> GetHistoricalConditions(string cityKey)
        {
            string uri = _appSettings.WeatherAPI.BaseUrl + "/" + string.Format(_appSettings.WeatherAPI.HistoricalEndpoint, cityKey, _appSettings.WeatherAPI.APIKey, _appSettings.DefaultLanguage);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                string json = await response.Content.ReadAsStringAsync();
                Weather[] weathers;
                weathers = JsonConvert.DeserializeObject<Weather[]>(json);
                Debug.Write(json);
                return weathers.FirstOrDefault();
            }
        }

        public async Task<DailyForecast[]> GetDailyForecast(string cityKey, int days)
        {
            string endPoint;
            switch(days)
            {
                case 1:
                    endPoint = _appSettings.WeatherAPI.Daily1Endpoint;
                    break;
                case 5:
                    endPoint = _appSettings.WeatherAPI.Daily5Endpoint;
                    break;
                default:
                    throw new Exception("Not supported number of days");
            }
            string uri = _appSettings.WeatherAPI.BaseUrl + "/" + string.Format(endPoint, cityKey, _appSettings.WeatherAPI.APIKey, _appSettings.DefaultLanguage);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                string json = await response.Content.ReadAsStringAsync();
                DailyForecast[] forecast = JsonConvert.DeserializeAnonymousType(json, new { DailyForecasts = new DailyForecast[days] }).DailyForecasts;
                Debug.Write(json);
                return forecast;
            }
        }

    }
}
