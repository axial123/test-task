using FastEndpoints;
using Microsoft.Extensions.Caching.Memory;

namespace Sofomo.Coordinates.Endpoints;

internal class Delete : Endpoint<DeleteCoordinatesById, GetAllCoordinatesResponse>
{
    private readonly ICoordinatesService _coordinatesService;
    private readonly IMemoryCache _cache;

    public Delete(ICoordinatesService coordinatesService, IMemoryCache cache)
    {
        _coordinatesService = coordinatesService;
        _cache = cache;
    }

    public override void Configure()
    {
        Delete("/api/coordinates/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeleteCoordinatesById request, CancellationToken cancellationToken)
    {
        await _coordinatesService.DeleteCoordinates(request.Id);

        _cache.Remove("all");

        await SendNoContentAsync();
    }
}