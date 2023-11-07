using P04WeatherForecastAPI.Client.ViewModels;
using System.Windows;

namespace P04WeatherForecastAPI.Client
{
    public partial class FlightsBrowserWindow : Window
    {
        public FlightsBrowserWindow(FlightViewModel flightsViewModel)
        {
            DataContext = flightsViewModel;
            InitializeComponent();
        }
    }
}
