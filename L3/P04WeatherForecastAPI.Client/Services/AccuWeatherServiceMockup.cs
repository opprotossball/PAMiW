using Newtonsoft.Json;
using P04WeatherForecastAPI.Client.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace P04WeatherForecastAPI.Client.Services
{
    internal class AccuWeatherServiceMockup : IAccuWeatherService
    {
        private static readonly string exampleWeatherPath = "C:\\Users\\janst\\source\\studia\\pamw\\repo\\L2\\P04WeatherForecastAPI.Client\\ExampleJsons\\Weather.json";
        private static readonly string exampleCitiesPath = "C:\\Users\\janst\\source\\studia\\pamw\\repo\\L2\\P04WeatherForecastAPI.Client\\ExampleJsons\\Cities.json";
        private static readonly string exampleForecast = "C:\\Users\\janst\\source\\studia\\pamw\\repo\\L2\\P04WeatherForecastAPI.Client\\ExampleJsons\\Forecast.json";

        private string Read(string path)
        {
            return File.ReadAllText(path);
            //return File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), path));
        }

        public async Task<Weather> GetCurrentConditions(string cityKey)
        {
            Weather[] weathers;
            string json = Read(exampleWeatherPath);
            weathers = JsonConvert.DeserializeObject<Weather[]>(json);
            return weathers.FirstOrDefault();
        }

        public async Task<DailyForecast[]> GetDailyForecast(string cityKey, int days)
        {
            DailyForecast[] dailyForecasts;
            string json = Read(exampleForecast);
            dailyForecasts = JsonConvert.DeserializeAnonymousType(json, new { DailyForecast = new DailyForecast[5] }).DailyForecast;
            return dailyForecasts;
        }

        public async Task<Weather> GetHistoricalConditions(string cityKey)
        {
            Weather[] weathers;
            string json = Read(exampleWeatherPath);
            weathers = JsonConvert.DeserializeObject<Weather[]>(json);
            return weathers.FirstOrDefault();
        }

        public async Task<City[]> GetLocations(string locationName)
        {
            City[] cities;
            string json = Read(exampleCitiesPath);
            cities = JsonConvert.DeserializeObject<City[]>(json);
            return cities;
        }
    }
}
