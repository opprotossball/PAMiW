using Microsoft.Extensions.Logging;
using P01TravelMobileApp.MessageBox;
using P01TravelMobileApp.ViewModels;
using P03Travel.Shared.Configuration;
using P03Travel.Shared.Messages;
using P03Travel.Shared.Services.FlightService;

namespace P01TravelMobileApp
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				});

#if DEBUG
			builder.Logging.AddDebug();
#endif
			ConfigureServices(builder.Services);
			return builder.Build();
		}

		private static void ConfigureServices(IServiceCollection services)
		{
			var appSettingsSection = ConfigureAppSettings(services);
			ConfigureAppServices(services, appSettingsSection);
			ConfigureViewModels(services);
			ConfigureViews(services);
			ConfigureHttpClients(services, appSettingsSection);
		}

		private static AppSettings ConfigureAppSettings(IServiceCollection services)
		{
			var appSettingsSection = new AppSettings()
			{
				FlightAPI = new FlightAPIConfiguration()
				{
					BaseUrl = "http://localhost:5093",
					FirstNFlightsEndpoint = "api/Flight/first?num={0}",
					GetByIdEndpoint = "api/Flight?id={0}",
					FlightEndpoint = "api/Flight",
					RelationEndpoint = "api/Flight/relation?from={0}&to={1}",
					SearchEndpoint = "api/Flight/search?search={0}&page={1}&pagesize={2}",
					ListEndpoint = "api/Flight/list?page={0}&pagesize={1}"
				}
			};
			services.AddSingleton(appSettingsSection);
			return appSettingsSection;
		}

		private static void ConfigureAppServices(IServiceCollection services, AppSettings appSettings)
		{
			services.AddSingleton<IConnectivity>(Connectivity.Current);
			services.AddSingleton<IGeolocation>(Geolocation.Default);
			services.AddSingleton<IMap>(Map.Default);
			services.AddSingleton<IFlightService, FlightService>();
			services.AddSingleton<IMessageBox, OkMessageBox>();
		}

		private static void ConfigureViewModels(IServiceCollection services)
		{
			services.AddSingleton<FlightsViewModel>();
			services.AddTransient<FlightDetailsViewModel>();
		}

		private static void ConfigureViews(IServiceCollection services)
		{
			services.AddSingleton<MainPage>();
			services.AddTransient<FlightDetailsView>();
		}

		private static void ConfigureHttpClients(IServiceCollection services, AppSettings appSettingsSection)
		{
			var uriBuilder = new UriBuilder(appSettingsSection.FlightAPI.BaseUrl);
			services.AddHttpClient<IFlightService, FlightService>(client => client.BaseAddress = uriBuilder.Uri);
		}
	}
}