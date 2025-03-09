using FastEndpoints;

namespace Sofomo.Coordinates.Endpoints;

internal class Delete(ICoordinatesService coordinatesService) : Endpoint<DeleteCoordinatesById, GetAllCoordinatesResponse>
{
    public override void Configure()
    {
        Delete("/api/coordinates/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeleteCoordinatesById request, CancellationToken cancellationToken)
    {
        await coordinatesService.DeleteCoordinates(request.Id);

        await SendNoContentAsync();
    }
}