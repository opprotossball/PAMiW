using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using P03Travel.Shared.Services.FlightService;
using P03Travel.Shared.Travels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04WeatherForecastAPI.Client.ViewModels
{
    public partial class FlightViewModel : ObservableObject
    {
        public string From { get; set; }
        public string To { get; set; }
        private readonly IFlightService _flightService;
        public ObservableCollection<Flight> Flights { get; set; }

        public FlightViewModel(IFlightService flightService)
        {
            _flightService = flightService;
            Flights = new ObservableCollection<Flight>();
        }

        [RelayCommand]
        public async void SearchFlights()
        {
            var result = await _flightService.GetFromToAsync(From, To);
            if (result.Success)
            {
                foreach (var f in result.Data)
                {
                    Flights.Add(f);
                }
            }
        }

        [RelayCommand]
        public async void ShowBestOffers()
        {
            var result = await _flightService.GetFlightsAsync(10);
            if (result.Success)
            {
                foreach (var f in result.Data)
                {
                    Flights.Add(f);
                }
            }
        }

    }
}
