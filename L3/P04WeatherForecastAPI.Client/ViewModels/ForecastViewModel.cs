using P04WeatherForecastAPI.Client.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace P04WeatherForecastAPI.Client.ViewModels
{
    public class ForecastViewModel
    {
        public List<DailyForecastViewModel> Forecasts { get; set; }
        public ForecastViewModel(DailyForecast[] dailyForecasts)
        {
            Forecasts = new List<DailyForecastViewModel>();
            foreach (DailyForecast dailyForecast in dailyForecasts)
            {
                Forecasts.Add(new DailyForecastViewModel(dailyForecast));
            }
        }
    }
}
