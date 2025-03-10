using FastEndpoints;
using Sofomo.Forecast.NewFolder;

namespace Sofomo.Forecast.ForecastEndpoints;

internal class GetByCoordinates(IForecastService forecastService) : Endpoint<GetByCoordinatesRequest>
{
    public override void Configure()
    {
        Get("/api/forecast");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetByCoordinatesRequest request, CancellationToken cancellationToken)
    {
        // add caching and fetch from there or add to cache if not exist
        var res = await forecastService.GetByCoordinates(request.Longitude, request.Latitude);

        await SendAsync(new GetByCooridnatesResponse()
        {
            Forecast = res
        });
    }
}
