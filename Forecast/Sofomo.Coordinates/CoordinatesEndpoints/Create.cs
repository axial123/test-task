using FastEndpoints;
using Microsoft.AspNetCore.Http;

namespace Sofomo.Coordinates.Endpoints;

internal class Create(ICoordinatesService coordinatesService) : Endpoint<CreateCoordinatesRequest, CoordinatesDto>
{
    public override void Configure()
    {
        Post("/api/coordinates");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateCoordinatesRequest request, CancellationToken cancellationToken)
    {
        var coordinatesDto = new CoordinatesDto(request.Latitude, request.Longitude);

        var coordinates = await coordinatesService.GetCoordinatesById(coordinatesDto.Id);

        if (coordinates is null)
        {
            await coordinatesService.AddCoordinates(coordinatesDto);

            await SendCreatedAtAsync<Create>(new { id = coordinatesDto.Id }, coordinatesDto);

            return;
        }
        await SendErrorsAsync(StatusCodes.Status409Conflict);
    }
}
