using P04WeatherForecastAPI.Client.ViewModels;
using System.Windows;

namespace P04WeatherForecastAPI.Client
{
    public partial class FlightsManagerWindow : Window
    {
        public FlightsManagerWindow(FlightManagerViewModel flightsViewModel)
        {
            DataContext = flightsViewModel;
            InitializeComponent();
        }
    }
}
