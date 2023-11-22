using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03Travel.Shared.Configuration
{
    public class AppSettings
    {
        public string DefaultLanguage { get; set; }
        public FlightAPIConfiguration FlightAPI { get; set; }
        public WeatherAPIConfiguration WeatherAPI { get; set; }
    }
}
