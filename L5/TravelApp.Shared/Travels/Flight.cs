namespace P03Travel.Shared.Travels
{
    public class Flight
    {
        public int Id { get; set; }
        public string Airlines { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int Price { get; set; }
        public DateTime DepartureTime { get; set; }
    }
}
