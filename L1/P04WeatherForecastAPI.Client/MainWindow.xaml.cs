using P04WeatherForecastAPI.Client.Models;
using P04WeatherForecastAPI.Client.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace P04WeatherForecastAPI.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AccuWeatherService accuWeatherService;
        Mode mode;

        public MainWindow()
        {
            InitializeComponent();
            mode = Mode.CurrentConditions;
            UpdateModeInfo();
            accuWeatherService = new AccuWeatherService();
        }

        private async void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            
            City[] cities= await accuWeatherService.GetLocations(txtCity.Text);

            // standardowy sposób dodawania elementów
            //lbData.Items.Clear();
            //foreach (var c in cities)
            //    lbData.Items.Add(c.LocalizedName);

            // teraz musimy skorzystac z bindowania danych bo chcemy w naszej kontrolce przechowywac takze id miasta 
            lbData.ItemsSource = cities;
        }

        private void btnCurrent_Click(object sender, RoutedEventArgs e)
        {
            mode = Mode.CurrentConditions;
            UpdateModeInfo();
        }

        private void btn1day_Click(object sender, RoutedEventArgs e)
        {
            mode = Mode.Forecast1day;
            UpdateModeInfo();
        }

        private void btn5days_Click(object sender, RoutedEventArgs e)
        {
            mode = Mode.Forecast5days;
            UpdateModeInfo();
        }

        private void btn10days_Click(object sender, RoutedEventArgs e)
        {
            mode = Mode.Forecast10days;
            UpdateModeInfo();
        }

        private void btnHistorical_Click(object sender, RoutedEventArgs e)
        {
            mode = Mode.Historical;
            UpdateModeInfo();
        }

        private async void lbData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCity= (City)lbData.SelectedItem;
            if(selectedCity != null)
            {
                lblCityName.Content = selectedCity.LocalizedName;
                if (mode == Mode.CurrentConditions)
                {
                    handleCurrentConditions(selectedCity.Key);
                }
                if (mode == Mode.Forecast1day || mode == Mode.Forecast5days || mode == Mode.Forecast10days)
                {
                    handleDailyForecast(selectedCity.Key);
                }
                if (mode == Mode.Historical)
                {
                    handleHistorical(selectedCity.Key);
                }
            }
        }

        private async void handleCurrentConditions(string selectedCityKey)
        {
            var weather = await accuWeatherService.GetCurrentConditions(selectedCityKey);
            double tempValue = weather.Temperature.Metric.Value;
            lblPrecipitation.Content = weather.HasPrecipitation ? "yes" : "no";
            lblTemperatureValue.Content = Convert.ToString(tempValue);
        }

        private async void handleDailyForecast(string selectedCityKey)
        {
            DailyForecast[] forecasts = await accuWeatherService.GetDailyForecast(selectedCityKey, (int)mode);
            string tempInfo = "";
            string precipitationInfo = "";
            if (forecasts == null)
            {
                throw new Exception("Forcasts is null");
            }
            foreach (DailyForecast forecast in forecasts)
            {
                double min = forecast.Temperature.Minimum.Value;
                double max = forecast.Temperature.Maximum.Value;
                if (forecast.Temperature.Minimum.Unit == "F")
                {
                    min = Math.Round(TemperatureConvert.F2C(min));
                }
                if (forecast.Temperature.Maximum.Unit == "F")
                {
                    max = Math.Round(TemperatureConvert.F2C(max));
                }
                tempInfo += Convert.ToString(min) + "-" + Convert.ToString(max) + "  ";
                precipitationInfo += forecast.Day.HasPrecipitation ? "yes  " : "no  ";
            }
            lblPrecipitation.Content = precipitationInfo;
            lblTemperatureValue.Content = tempInfo;
        }

        private async void handleHistorical(string selectedCityKey)
        {
            var weather = await accuWeatherService.GetCurrentConditions(selectedCityKey);
            double tempValue = weather.Temperature.Metric.Value;
            lblPrecipitation.Content = weather.HasPrecipitation ? "yes" : "no";
            lblTemperatureValue.Content = Convert.ToString(tempValue);
        }

        private void UpdateModeInfo()
        {
            switch (mode)
            {
                case Mode.CurrentConditions:
                    lblMode.Content = "Current Conditions";
                    break;
                case Mode.Forecast1day:
                    lblMode.Content = "1 Day Forecast";
                    break;
                case Mode.Forecast5days:
                    lblMode.Content = "5 Days Forecast";
                    break;
                case Mode.Forecast10days:
                    lblMode.Content = "10 Day Forecast";
                    break;
                case Mode.Historical:
                    lblMode.Content = "Yesterday";
                    break;
            }
        }
    }

}
