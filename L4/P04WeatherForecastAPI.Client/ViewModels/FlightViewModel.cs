using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using P03Travel.Shared.Services.FlightService;
using P03Travel.Shared.Travels;
using System;
using System.Collections.ObjectModel;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace P04WeatherForecastAPI.Client.ViewModels
{
    public partial class FlightViewModel : ObservableObject
    {
        public string From { get; set; }
        public string To { get; set; }
        private readonly IFlightService _flightService;
        private readonly IServiceProvider _serviceProvider;
        public ObservableCollection<Flight> Flights { get; set; }

        public FlightViewModel(IFlightService flightService, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _flightService = flightService;
            Flights = new ObservableCollection<Flight>();
        }

        [RelayCommand]
        public async void SearchFlights()
        {
            //Flights = new ObservableCollection<Flight>();
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
            //Flights = new ObservableCollection<Flight>();
            var result = await _flightService.GetFlightsAsync(10);
            if (result.Success)
            {
                foreach (var f in result.Data)
                {
                    Flights.Add(f);
                }
            }
        }

        [RelayCommand]
        public void OpenFlightManager()
        {
            FlightsManagerWindow flightsManagerWindow = _serviceProvider.GetService<FlightsManagerWindow>();
            flightsManagerWindow.Show();
        }
    }
}
