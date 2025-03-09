using FastEndpoints;

namespace Sofomo.Coordinates.Endpoints;

internal class GetAll(ICoordinatesService coordinatesService) : EndpointWithoutRequest<GetAllCoordinatesResponse>
{
    public override void Configure()
    {
        Get("/api/coordinates");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var coordinates = await coordinatesService.GetAllCoordinates();

        await SendAsync(new GetAllCoordinatesResponse()
        {
            Coordinates = coordinates
        });
    }
}