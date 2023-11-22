using System;
using System.Collections.Generic;

namespace P03Travel.Shared.WeatherModels
{
    public class DailyForecast
    {
        public DateTime Date { get; set; }
        public int EpochDate { get; set; }
        public ForecastTemperature Temperature { get; set; }
        public List<string> Sources { get; set; }
        public string MobileLink { get; set; }
        public string Link { get; set; }
        public Day Day { get; set; }
    }
}
