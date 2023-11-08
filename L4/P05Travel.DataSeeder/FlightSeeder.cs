using Bogus;
using P03Travel.Shared.Travels;

namespace P05Travel.DataSeeder
{
    public class FlightSeeder
    {
        static readonly string[] airlines = new string[] { "Ryanair", "Lufthansa", "KLM", "LOT", "Aeroflot", "Turkish Airlines" };
        public static List<Flight> GenerateFlightData(int count)
        {
            string codeCharset = "ABCDEFGHIJKLMNOPQRSTUWXYZ";
            int id = 1;
            var flightFaker = new Faker<Flight>("en")
                .UseSeed(222222)
                .RuleFor(x => x.Id, x => id++)
                .RuleFor(x => x.Airlines, x => x.PickRandom(airlines))
                .RuleFor(x => x.From, x => x.Random.String2(3, codeCharset))
                .RuleFor(x => x.To, x => x.Random.String2(3, codeCharset))
                .RuleFor(x => x.Price, x => x.Random.Int(100, 500))
                .RuleFor(x => x.DepartureTime, x => x.Date.Soon());
            return flightFaker.Generate(count).ToList();
        }
    }
}