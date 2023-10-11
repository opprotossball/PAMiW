using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using P04WeatherForecastAPI.Client.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace P04WeatherForecastAPI.Client.Services
{
    internal class AccuWeatherService
    {
        private const string base_url = "http://dataservice.accuweather.com";
        private const string autocomplete_endpoint = "locations/v1/cities/autocomplete?apikey={0}&q={1}&language{2}";
        private const string current_conditions_endpoint = "currentconditions/v1/{0}?apikey={1}&language{2}";
        private const string daily_1_forecast_endpoint = "forecasts/v1/daily/1day/{0}?apikey={1}&language{2}";
        private const string daily_5_forecast_endpoint = "forecasts/v1/daily/5day/{0}?apikey={1}&language{2}";
        private const string daily_10_forecast_endpoint = "forecasts/v1/daily/10day/{0}?apikey={1}&language{2}";
        private const string historical_conditions_endpoint = "currentconditions/v1/{0}/historical/24?apikey={1}&language{2}";

        string api_key;
        string language; 


        public AccuWeatherService()
        {
            var builder = new ConfigurationBuilder()
                .AddUserSecrets<App>()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetings.json"); 

            var configuration = builder.Build();
            api_key = configuration["api_key"];
            language = configuration["default_language"];
        }


        public async Task<City[]> GetLocations(string locationName)
        {
            string uri = base_url + "/" + string.Format(autocomplete_endpoint, api_key, locationName, language);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                string json = await response.Content.ReadAsStringAsync();
                Debug.Write(json);
                City[] cities = JsonConvert.DeserializeObject<City[]>(json);
                return cities;
            }
        }

        public async Task<Weather> GetCurrentConditions(string cityKey)
        {
            string uri = base_url + "/" + string.Format(current_conditions_endpoint, cityKey, api_key, language);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                string json = await response.Content.ReadAsStringAsync();
                Weather[] weathers = JsonConvert.DeserializeObject<Weather[]>(json);
                return weathers.FirstOrDefault();
            }
        }

        public async Task<Weather> GetHistoricalConditions(string cityKey)
        {
            string uri = base_url + "/" + string.Format(historical_conditions_endpoint, cityKey, api_key, language);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                string json = await response.Content.ReadAsStringAsync();
                Weather[] weathers = JsonConvert.DeserializeObject<Weather[]>(json);
                return weathers.FirstOrDefault();
            }
        }

        public async Task<DailyForecast[]> GetDailyForecast(string cityKey, int days)
        {
            string endPoint;
            switch(days)
            {
                case 1:
                    endPoint = daily_1_forecast_endpoint;
                    break;
                case 5:
                    endPoint = daily_5_forecast_endpoint;
                    break;
                case 10:
                    endPoint = daily_10_forecast_endpoint;
                    break;
                default:
                    throw new Exception("Not supported number of days");
            }
            string uri = base_url + "/" + string.Format(endPoint, cityKey, api_key, language);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                string json = await response.Content.ReadAsStringAsync();
                var type = new { forecasts = new DailyForecast[days] };
                return JsonConvert.DeserializeAnonymousType(json, type).forecasts;
            }
        }

    }
}
