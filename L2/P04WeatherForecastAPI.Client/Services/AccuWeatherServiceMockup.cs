using Newtonsoft.Json;
using P04WeatherForecastAPI.Client.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04WeatherForecastAPI.Client.Services
{
    internal class AccuWeatherServiceMockup : IAccuWeatherService
    {
        private readonly string exampleWeatherPath = "C:\\Users\\janst\\source\\studia\\pamw\\repo\\L2\\P04WeatherForecastAPI.Client\\ExampleJsons\\Weather.json";
        private readonly string exampleCitiesPath = "C:\\Users\\janst\\source\\studia\\pamw\\repo\\L2\\P04WeatherForecastAPI.Client\\ExampleJsons\\Cities.json";

        public async Task<Weather> GetCurrentConditions(string cityKey)
        {
            Weather[] weathers;
            string json = File.ReadAllText(exampleWeatherPath);
            weathers = JsonConvert.DeserializeObject<Weather[]>(json);
            return weathers.FirstOrDefault();
        }

        public async Task<DailyForecast[]> GetDailyForecast(string cityKey, int days)
        {
            throw new NotImplementedException();
        }

        public async Task<Weather> GetHistoricalConditions(string cityKey)
        {
            Weather[] weathers;
            string json = File.ReadAllText(exampleWeatherPath);
            weathers = JsonConvert.DeserializeObject<Weather[]>(json);
            return weathers.FirstOrDefault();
        }

        public async Task<City[]> GetLocations(string locationName)
        {
            City[] cities;
            string json = File.ReadAllText(exampleCitiesPath);
            cities = JsonConvert.DeserializeObject<City[]>(json);
            return cities;
        }
    }
}
