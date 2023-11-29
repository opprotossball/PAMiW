using P03Travel.Shared.WeatherModels;

namespace P03Travel.Shared.Services.WeatherService
{
    public interface IAccuWeatherService
    {
        Task<City[]> GetLocations(string locationName);
        Task<Weather> GetCurrentConditions(string cityKey);
        Task<Weather> GetHistoricalConditions(string cityKey);
        Task<DailyForecast[]> GetDailyForecast(string cityKey, int days);
    }
}
