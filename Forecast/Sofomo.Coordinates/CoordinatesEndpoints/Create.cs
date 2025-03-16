using FastEndpoints;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;

namespace Sofomo.Coordinates.Endpoints;

internal class Create : Endpoint<CreateCoordinatesRequest, CoordinatesDto>
{
    private readonly ICoordinatesService _coordinatesService;
    private readonly IMemoryCache _cache;

    public Create(ICoordinatesService coordinatesService, IMemoryCache cache)
    {
        _coordinatesService = coordinatesService;
        _cache = cache;
    }

    public override void Configure()
    {
        Post("/api/coordinates");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateCoordinatesRequest request, CancellationToken cancellationToken)
    {
        var coordinatesDto = new CoordinatesDto(request.Latitude, request.Longitude);

        var coordinates = await _coordinatesService.GetCoordinatesById(coordinatesDto.Id);

        if (coordinates is null)
        {
            await _coordinatesService.AddCoordinates(coordinatesDto);

            _cache.Remove("all");

            await SendCreatedAtAsync<Create>(new { id = coordinatesDto.Id }, coordinatesDto);

            return;
        }

        await SendErrorsAsync(StatusCodes.Status409Conflict);
    }
}
