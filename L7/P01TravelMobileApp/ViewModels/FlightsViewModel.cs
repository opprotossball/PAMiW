using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using P01TravelMobileApp;
using P03Travel.Shared.Messages;
using P03Travel.Shared.Services.FlightService;
using P03Travel.Shared.Travels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace P01TravelMobileApp.ViewModels
{

	public partial class FlightsViewModel : ObservableObject
	{
		private readonly IFlightService _flightService;
		private readonly FlightDetailsView _flightDetailsView;
		private readonly IMessageBox _messageDialogService;
		private readonly IConnectivity _connectivity;
		public ObservableCollection<Flight> Flights { get; set; }

		[ObservableProperty]
		private Flight selectedFlight;

		public FlightsViewModel(IFlightService flightService, FlightDetailsView flightDetailsView, IMessageBox messageDialogService,
			IConnectivity connectivity)
		{
			_messageDialogService = messageDialogService;
			_flightDetailsView = flightDetailsView;
			_flightService = flightService;
			_connectivity = connectivity;
			Flights = new ObservableCollection<Flight>();
			GetFlights();
		}

		public async Task GetFlights()
		{
			Flights.Clear();
			if (_connectivity.NetworkAccess != NetworkAccess.Internet)
			{
				_messageDialogService.ShowMessage("Internet not available!");
				return;
			}
			var flightsResult = await _flightService.GetFlightsAsync(10);
			if (flightsResult.Success)
			{
				foreach (var p in flightsResult.Data)
				{
					Flights.Add(p);
				}
			}
			else
			{
				_messageDialogService.ShowMessage(flightsResult.Message);
			}
		}

		[RelayCommand]
		public async Task ShowDetails(Flight flight)
		{
			if (_connectivity.NetworkAccess != NetworkAccess.Internet)
			{
				_messageDialogService.ShowMessage("Internet not available!");
				return;
			}

			await Shell.Current.GoToAsync(nameof(FlightDetailsView), true, new Dictionary<string, object>
			{
				{"Flight", flight },
				{nameof(FlightsViewModel), this }
			});
			SelectedFlight = flight;
		}

		[RelayCommand]
		public async Task New()
		{
			Debug.WriteLine("okok");
			if (_connectivity.NetworkAccess != NetworkAccess.Internet)
			{
				_messageDialogService.ShowMessage("Internet not available!");
				return;
			}

			SelectedFlight = new Flight();
			await Shell.Current.GoToAsync(nameof(FlightDetailsView), true, new Dictionary<string, object>
			{
				{"Flight", SelectedFlight },
				{nameof(FlightsViewModel), this }
			});
		}

	}
}
