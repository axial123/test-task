using FastEndpoints;
using Microsoft.Extensions.Caching.Memory;

namespace Sofomo.Coordinates.Endpoints;

internal class GetAll : EndpointWithoutRequest<GetAllCoordinatesResponse>
{
    private readonly IMemoryCache _cache;
    private readonly ICoordinatesService _coordinatesService;

    public GetAll(ICoordinatesService coordinatesService, IMemoryCache cache)
    {
        _coordinatesService = coordinatesService;
        _cache = cache;
    }

    public override void Configure()
    {
        Get("/api/coordinates");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        if (_cache.TryGetValue("all", out IEnumerable<CoordinatesDto> cachedCoordinates))
        {
            await SendAsync(new GetAllCoordinatesResponse()
            {
                Coordinates = cachedCoordinates
            });

            return;
        }

        var coordinates = await _coordinatesService.GetAllCoordinates();

        if (coordinates.Any())
        {
            _cache.Set("all", coordinates, TimeSpan.FromHours(24));
        }

        await SendAsync(new GetAllCoordinatesResponse()
        {
            Coordinates = coordinates
        });
    }
}