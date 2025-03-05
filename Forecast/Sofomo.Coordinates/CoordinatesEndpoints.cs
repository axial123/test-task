using FastEndpoints;

namespace Sofomo.Coordinates;

public class CoordinatesResponse
{
    public IEnumerable<CoordinatesDto> Coordinates { get; init; }
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
        var coordinates = await coordinatesService.GetAllCoordinates();

        await SendAsync(new CoordinatesResponse()
        {
            Coordinates = coordinates
        });
    }
}