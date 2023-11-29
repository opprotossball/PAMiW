using P03Travel.Shared.Configuration;
using P03Travel.Shared.Services.FlightService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var appSettings = builder.Configuration.GetSection(nameof(AppSettings));
var appSettingsSection = appSettings.Get<AppSettings>();

var uriBuilder = new UriBuilder(appSettingsSection.FlightAPI.BaseUrl);

builder.Services.AddHttpClient<IFlightService, FlightService>(client => client.BaseAddress = uriBuilder.Uri);
builder.Services.Configure<AppSettings>(appSettings);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
