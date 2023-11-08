namespace P04WeatherForecastAPI.Client.Configuration
{
    internal class FlightAPIConfiguration
    {
        public string BaseUrl { get; set; }
        public string FirstNFlightsEndpoint { get; set; }
        public string GetByIdEndpoint { get; set; }
        public string FlightEndpoint { get; set; }
        public string RelationEndpoint { get; set; }
    }
}
