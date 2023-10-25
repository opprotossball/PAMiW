using P04WeatherForecastAPI.Client.Models;

namespace P04WeatherForecastAPI.Client.ViewModels
{
    public class WeatherViewModel
    {
        private static readonly string rainImagePath = "/Images/rain.png";
        private static readonly string sunImagePath = "/Images/sun.png";

        public string Image
        {
            get
            {
                return HasPrecipitation ? rainImagePath : sunImagePath;
            }
        }
        public WeatherViewModel(Weather weather)
        {
            CurrentTemperature = weather.Temperature.Metric.Value;
            HasPrecipitation = weather.HasPrecipitation;
            WeatherText = weather.WeatherText;
        }
        public double CurrentTemperature { get; set; }
        public string WeatherText { get; set; }
        public bool HasPrecipitation { get; set; }
    }
}
