using Microsoft.Extensions.DependencyInjection;

namespace Sofomo.Coordinates;

public static class CoordinatesServiceExtentionMethod
{
    public static IServiceCollection AddCoordinatesService(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ICoordinatesService, CoordinatesService>();
        return serviceCollection;
    }
}