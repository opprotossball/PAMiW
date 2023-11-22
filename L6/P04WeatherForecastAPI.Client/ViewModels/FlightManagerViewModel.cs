using System;
using System.Diagnostics;
using System.Linq;
using CommunityToolkit.Mvvm.Input;
using P03Travel.Shared.Services.FlightService;
using P03Travel.Shared.Travels;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public partial class FlightManagerViewModel : INotifyPropertyChanged
{
    public static readonly int AirportCodeLength = 3;

    private int? flightID;
    public int? FlightID
    {
        get => flightID;
        set
        {
            if (flightID != value)
            {
                flightID = value;
                OnPropertyChanged();
            }
        }
    }

    private string? flightAirlines;
    public string? FlightAirlines
    {
        get => flightAirlines;
        set
        {
            if (flightAirlines != value)
            {
                flightAirlines = value;
                OnPropertyChanged();
            }
        }
    }

    private string? flightFrom;
    public string? FlightFrom
    {
        get => flightFrom;
        set
        {
            if (flightFrom != value)
            {
                flightFrom = value;
                OnPropertyChanged();
            }
        }
    }

    private string? flightTo;
    public string? FlightTo
    {
        get => flightTo;
        set
        {
            if (flightTo != value)
            {
                flightTo = value;
                OnPropertyChanged();
            }
        }
    }

    private int? flightPrice;
    public int? FlightPrice
    {
        get => flightPrice;
        set
        {
            if (flightPrice != value)
            {
                flightPrice = value;
                OnPropertyChanged();
            }
        }
    }

    private DateTime? flightDeparture;
    public DateTime? FlightDeparture
    {
        get => flightDeparture;
        set
        {
            if (flightDeparture != value)
            {
                flightDeparture = value;
                OnPropertyChanged();
            }
        }
    }

    private readonly IFlightService _flightService;

    public FlightManagerViewModel(IFlightService flightService)
    {
        _flightService = flightService;
    }

    [RelayCommand]
    public async void DeleteFlight()
    {
        if (FlightID != null)
        {
            await _flightService.DeleteFlightAsync((int)FlightID);
            ClearAll();
        }
    }

    [RelayCommand]
    public async void AddFlight()
    {
        if (!ValidateFlightParms())
        {
            return;
        }
        await _flightService.AddFlightAsync(BuildFlight());
        ClearAll();
    }

    [RelayCommand]
    public async void ModifyFlight()
    {
        if (!ValidateFlightParms() || FlightID == null)
        {
            return;
        }
        Flight flight = BuildFlight();
        flight.Id = (int)FlightID;
        await _flightService.ModifyFlightAsync(flight);
        ClearAll();
    }

    private Flight BuildFlight()
    {
        return new Flight()
        {
            Airlines = FlightAirlines,
            From = FlightFrom,
            To = FlightTo,
            Price = (int)FlightPrice,
            DepartureTime = (DateTime)FlightDeparture
        };
    }

    private bool ValidateFlightParms()
    {
        if (string.IsNullOrEmpty(FlightAirlines))
        {
            Debug.WriteLine("Airlines is null or empty");
            return false;
        }
        if (string.IsNullOrEmpty(FlightFrom) || FlightFrom.Length != AirportCodeLength || !FlightFrom.All(char.IsUpper))
        {
            Debug.WriteLine($"Invalid 'From' value: {FlightFrom}");
            return false;
        }
        if (string.IsNullOrEmpty(FlightTo) || FlightTo.Length != AirportCodeLength || !FlightTo.All(char.IsUpper))
        {
            Debug.WriteLine($"Invalid 'To' value: {FlightTo}");
            return false;
        }
        if (FlightPrice == null)
        {
            Debug.WriteLine("Price is null");
            return false;
        }
        if (FlightDeparture == null)
        {
            Debug.WriteLine("Departure is null");
            return false;
        }
        return true;
    }

    private void ClearAll()
    {
        FlightID = null;
        FlightAirlines = string.Empty;
        FlightFrom = string.Empty;
        FlightTo = string.Empty;
        FlightPrice = null;
        FlightDeparture = null;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
