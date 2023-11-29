using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.ApplicationModel;
using P03Travel.Shared.Messages;
using P03Travel.Shared.Services.FlightService;
using P03Travel.Shared.Travels;

namespace P01TravelMobileApp.ViewModels
{
	[QueryProperty(nameof(Flight), nameof(Flight))]
	[QueryProperty(nameof(FlightsViewModel), nameof(FlightsViewModel))]
	public partial class FlightDetailsViewModel : ObservableObject
	{
		private readonly IFlightService _flightService;
		private readonly IMessageBox _messageBox;
		private readonly IGeolocation _geolocation;
		private readonly IMap _map;
		private FlightsViewModel _flightViewModel;

		public FlightDetailsViewModel(IFlightService flightService, IMessageBox messageBox, IGeolocation geolocation, IMap map)
		{
			_map = map;
			_flightService = flightService;
			_messageBox = messageBox;
			_geolocation = geolocation;
		}

		[RelayCommand]
		public async Task GetLocation()
		{
			var location = await _geolocation.GetLastKnownLocationAsync();

			try
			{
				await _map.OpenAsync(52.23564245654427, 21.0112328246909, new MapLaunchOptions
				{
					Name = "ALX",
					NavigationMode = NavigationMode.None
				});
			}
			catch (Exception)
			{
				_messageBox.ShowMessage("Error opening map");
			}

		}

		public FlightsViewModel FlightsViewModel
		{
			get
			{
				return _flightViewModel;
			}
			set
			{
				_flightViewModel = value;
			}
		}


		[ObservableProperty]
		Flight flight;

		public async Task DeleteFlight()
		{
			await _flightService.DeleteFlightAsync(flight.Id);
			await _flightViewModel.GetFlights();
		}

		public async Task CreateFlight()
		{
			var newFlight = new Flight()
			{
				Airlines = flight.Airlines,
				From = flight.From,
				To = flight.To,
				Price = flight.Price,
				DepartureTime = flight.DepartureTime
			};

			var result = await _flightService.AddFlightAsync(newFlight);
			if (result.Success)
			{
				await _flightViewModel.GetFlights();
			}
			else
			{
				_messageBox.ShowMessage(result.Message);
			}
		}

		public async Task UpdateFlight()
		{
			var flightToUpdate = new Flight()
			{
				Id = flight.Id,
				Airlines = flight.Airlines,
				From = flight.From,
				To = flight.To,
				Price = flight.Price,
				DepartureTime = flight.DepartureTime
			};

			var result = await _flightService.ModifyFlightAsync(flightToUpdate);
			if (result.Success)
			{
				await _flightViewModel.GetFlights();
			}
			else
			{
				_messageBox.ShowMessage(result.Message);
			}
		}


		[RelayCommand]
		public async Task Save()
		{
			if (flight.Id == 0)
			{
				await CreateFlight();
				await Shell.Current.GoToAsync("../", true);

			}
			else
			{
				await UpdateFlight();
				await Shell.Current.GoToAsync("../", true);
			}

		}

		[RelayCommand]
		public async Task Delete()
		{
			await DeleteFlight();
			await Shell.Current.GoToAsync("../", true);
		}
	}
}
