using FastEndpoints;
using Sofomo.Coordinates;
using Sofomo.Forecast;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFastEndpoints();

builder.Services.AddCoordinatesModule(builder.Configuration);
builder.Services.AddForecastModule(builder.Configuration);
builder.Services.AddMemoryCache();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseFastEndpoints();

app.MapControllers();

//app.MapCoordinatesEndpoints();

app.Run();

public partial class Program { }
