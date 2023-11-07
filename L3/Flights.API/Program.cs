using P02Travel.API.Services.FlightService;
using P03Travel.Shared.Services.FlightService;

//using P05Travel.DataSeeder;
//using P03Travel.Shared.Travels;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IFlightService, FlightService>();

var app = builder.Build();

if (true) //app.Environment.IsDevelopment()
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();