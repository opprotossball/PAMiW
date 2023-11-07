namespace P04WeatherForecastAPI.Client.Configuration
{
    internal class WeatherAPIConfiguration
    {
        public string BaseUrl { get; set; }
        public string APIKey { get; set; }
        public string AutocompleteEndpoint { get; set; }
        public string CurrentConditionsEndpoint { get; set; }
        public string Daily1Endpoint { get; set; }
        public string Daily5Endpoint { get; set; }
        public string HistoricalEndpoint { get; set; }
    }
}
