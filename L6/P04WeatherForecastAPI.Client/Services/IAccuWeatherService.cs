using P04WeatherForecastAPI.Client.Models;
using System.Threading.Tasks;

namespace P04WeatherForecastAPI.Client.Services
{
    public interface IAccuWeatherService
    {
        Task<City[]> GetLocations(string locationName);
        Task<Weather> GetCurrentConditions(string cityKey);
        Task<Weather> GetHistoricalConditions(string cityKey);
        Task<DailyForecast[]> GetDailyForecast(string cityKey, int days);
    }
}
