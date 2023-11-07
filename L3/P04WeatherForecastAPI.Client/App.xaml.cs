using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using P03Travel.Shared.Services.FlightService;
using P04WeatherForecastAPI.Client.Configuration;
using P04WeatherForecastAPI.Client.Services;
using P04WeatherForecastAPI.Client.ViewModels;
using System;
using System.IO;
using System.Windows;
using System.Diagnostics;

namespace P04WeatherForecastAPI.Client
{
    public partial class App : Application
    {
        IServiceProvider _serviceProvider;
        IConfiguration _configuration;

        public App()
        {
            var builder = new ConfigurationBuilder()
              .AddUserSecrets<App>()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json");
            _configuration = builder.Build();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            var appSettingsSection = ConfigureAppSettings(services);
            ConfigureAppServices(services);
            ConfigureViewModels(services);
            ConfigureViews(services);
            ConfigureHttpClients(services, appSettingsSection);
        }

        private AppSettings ConfigureAppSettings(IServiceCollection services)
        {
            var appSettings = _configuration.GetSection(nameof(AppSettings));
            Debug.WriteLine(appSettings.GetType());
            var appSettingsSection = appSettings.Get<AppSettings>();
            Debug.WriteLine(appSettingsSection.GetType());
            services.Configure<AppSettings>(appSettings);
            return appSettingsSection;
        }

        private void ConfigureAppServices(IServiceCollection services)
        {
            services.AddSingleton<IAccuWeatherService, AccuWeatherService>();
            services.AddSingleton<IFlightService, FlightService>();
        }

        private void ConfigureViewModels(IServiceCollection services)
        {

            services.AddSingleton<MainViewModel>();
            services.AddSingleton<FlightViewModel>();
        }

        private void ConfigureViews(IServiceCollection services)
        {
            services.AddTransient<MainWindow>();
            services.AddTransient<FlightsBrowserWindow>();
        }

        private void ConfigureHttpClients(IServiceCollection services, AppSettings appSettingsSection)
        {
            var uriBuilder = new UriBuilder(appSettingsSection.FlightAPI.BaseUrl);
            services.AddHttpClient<IFlightService, FlightService>(client => client.BaseAddress = uriBuilder.Uri);
        }


        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
    
}
