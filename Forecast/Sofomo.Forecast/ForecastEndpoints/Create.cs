using FastEndpoints;

namespace Sofomo.Forecast.ForecastEndpoints;

internal class Create(IForecastService forecastService) : Endpoint<CreateForecastRequest, ForecastDto>
{
    public override void Configure()
    {
        Post("/api/forecast");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateForecastRequest request, CancellationToken cancellationToken)
    {
        var forecastDto = new ForecastDto(request.Temperature, request.Time, request.Latitude, request.Longitude);
        var result = await forecastService.AddForecast(forecastDto);

        await SendCreatedAtAsync<Create>(new { result.Id }, result);
    }
}
