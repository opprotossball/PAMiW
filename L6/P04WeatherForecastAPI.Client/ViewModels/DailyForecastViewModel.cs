using P04WeatherForecastAPI.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04WeatherForecastAPI.Client.ViewModels
{
    public class DailyForecastViewModel
    {
        private static readonly string rainImagePath = "/Images/rain.png";
        private static readonly string sunImagePath = "/Images/sun.png";
        public double MinTemperature { get; set; }
        public double MaxTemperature { get; set; }
        public string ImagePath { get; set; }

        public DailyForecastViewModel(DailyForecast dailyForecast) 
        {
            MinTemperature = TemperatureConvert.F2C(dailyForecast.Temperature.Minimum.Value);
            MaxTemperature = TemperatureConvert.F2C(dailyForecast.Temperature.Maximum.Value);
            ImagePath = dailyForecast.Day.HasPrecipitation ? rainImagePath : sunImagePath;
        }
    }
}
