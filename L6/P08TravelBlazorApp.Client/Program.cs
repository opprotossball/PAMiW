using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using P03Travel.Shared.Configuration;
using Microsoft.Extensions.Options;
using P03Travel.Shared.Services.FlightService;
using P08TravelBlazorApp.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var appSettings = builder.Configuration.GetSection(nameof(AppSettings));
var appSettingsSection = appSettings.Get<AppSettings>();

var uriBuilder = new UriBuilder(appSettingsSection.FlightAPI.BaseUrl);

builder.Services.AddHttpClient<IFlightService, FlightService>(client => client.BaseAddress = uriBuilder.Uri);
builder.Services.AddSingleton<IOptions<AppSettings>>(new OptionsWrapper<AppSettings>(appSettingsSection));

await builder.Build().RunAsync();
