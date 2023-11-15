﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using P04WeatherForecastAPI.Client.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace P04WeatherForecastAPI.Client.ViewModels
{

    public partial class MainViewModel : ObservableObject, INotifyPropertyChanged
    {
        public ObservableCollection<CityViewModel> Cities { get; set; }
        private Mode _mode;
        private WeatherViewModel _weatherView;
        private ForecastViewModel _dailyForecasts;
        public ObservableCollection<Mode> Modes { get; set; }
        private CityViewModel _selectedCity;
        private readonly IAccuWeatherService _accuWeatherService;
        private readonly IServiceProvider _serviceProvider;
        public event PropertyChangedEventHandler? PropertyChanged;

        public MainViewModel(IAccuWeatherService accuWeatherService, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _accuWeatherService = accuWeatherService;
            Cities = new ObservableCollection<CityViewModel>();
            Modes = new ObservableCollection<Mode>();
            foreach (Mode mode in Enum.GetValues(typeof(Mode)))
            {
                Modes.Add(mode);
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ForecastViewModel DailyForecasts
        {
            get { return _dailyForecasts; }
            set
            {
                _dailyForecasts = value;
                OnPropertyChanged();
            }
        }

        public WeatherViewModel WeatherView
        {
            get { return _weatherView; }
            set
            {
                _weatherView = value;
                OnPropertyChanged();
            }
        }

        public Mode Mode
        {
            get { return _mode; }
            set
            {
                _mode = value;
                OnPropertyChanged();
                LoadWeather();
            }
        }

        public CityViewModel SelectedCity
        {
            get => _selectedCity;
            set
            {
                _selectedCity = value;
                OnPropertyChanged();
                LoadWeather();
            }
        }

        [RelayCommand]
        public async void LoadCities(string locationName)
        {
            if (locationName == null || locationName.Length == 0) 
            {
                return;
            }
            var cities = await _accuWeatherService.GetLocations(locationName);
            Cities.Clear();
            foreach (var city in cities)
            {
                Cities.Add(new CityViewModel(city));
            }
        }

        [RelayCommand]
        public void OpenFlightsWindow()
        {
            FlightsBrowserWindow flightsBrowserView = _serviceProvider.GetService<FlightsBrowserWindow>();
            flightsBrowserView.Show();
        }

        private async void LoadWeather()
        {
            if (SelectedCity != null)
            {
                ClearAll();
                if (Mode == Mode.CurrentConditions)
                {
                    GetCurrentConditions(SelectedCity.Key);
                }
                if (Mode == Mode.Forecast1day || Mode == Mode.Forecast5days)
                {
                    GetDailyForecast(SelectedCity.Key);
                }
                if (Mode == Mode.Historical)
                {
                    GetHistorical(SelectedCity.Key);
                }
            }
        }

        private void ClearAll()
        {
            WeatherView = null;
            DailyForecasts = null;
        }

        private async void GetCurrentConditions(string selectedCityKey)
        {
            WeatherView = new WeatherViewModel(await _accuWeatherService.GetCurrentConditions(selectedCityKey));
        }

        private async void GetDailyForecast(string selectedCityKey)
        {
            DailyForecasts = new ForecastViewModel(await _accuWeatherService.GetDailyForecast(selectedCityKey, (int)Mode));
        }

        private async void GetHistorical(string selectedCityKey)
        {
            WeatherView = new WeatherViewModel(await _accuWeatherService.GetHistoricalConditions(selectedCityKey));
        }

    }
}
