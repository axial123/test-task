using FastEndpoints;

namespace Sofomo.Coordinates;

public class CoordinatesResponse
{
    public List<CoordinatesDto> Coordinates { get; init; }
}

internal class CoordinatesEndpoint(ICoordinatesService coordinatesService) : EndpointWithoutRequest<CoordinatesResponse>
{
    public override void Configure()
    {
        Get("/api/coordinates");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var coordinates = coordinatesService.GetCoordinates();

        await SendAsync(new CoordinatesResponse()
        {
            Coordinates = coordinates
        });
    }
}