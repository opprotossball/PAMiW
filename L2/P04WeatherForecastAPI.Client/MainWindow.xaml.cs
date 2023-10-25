using P04WeatherForecastAPI.Client.Models;
using P04WeatherForecastAPI.Client.Services;
using P04WeatherForecastAPI.Client.ViewModels;
using System.Windows;


namespace P04WeatherForecastAPI.Client
{
    public partial class MainWindow : Window
    {
        AccuWeatherService accuWeatherService;
        Mode Mode { get; set; }
        MainViewModel _mainViewModel;

        public MainWindow(MainViewModel mainViewModel)
        {
            
            InitializeComponent();
            _mainViewModel = mainViewModel;
            DataContext = _mainViewModel;
            Mode = Mode.CurrentConditions;
            accuWeatherService = new AccuWeatherService();
        }
    }
}
