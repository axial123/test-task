using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Sofomo.Coordinates;

public static class CoordinatesEndpoints
{
    public static void MapCoordinatesEndpoints (this WebApplication application)
    {
        application.MapGet("/coordinates", (ICoordinatesService service) =>
        {
            return service.GetCoordinates();
        });
    }

}

internal class CoordinatesService : ICoordinatesService
{
    public IEnumerable<CoordinatesDto> GetCoordinates()
    {
        return new List<CoordinatesDto>()
        {
            new CoordinatesDto(51.1172642,17.0215266),
            new CoordinatesDto(51.097800, 17.032707),
            new CoordinatesDto(51.1075504,17.0690172)
        };
    }
}

public static class CoordinatesServiceExtentionMethod
{
    public static IServiceCollection AddCooridnatesService(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ICoordinatesService, CoordinatesService>();
        return serviceCollection;
    }
}