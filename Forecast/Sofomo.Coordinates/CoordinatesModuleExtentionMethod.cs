using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sofomo.Coordinates.Data;

namespace Sofomo.Coordinates;

public static class CoordinatesModuleExtentionMethod
{
    public static IServiceCollection AddCoordinatesModule(this IServiceCollection serviceCollection, ConfigurationManager configuration)
    {
        var connectionString = configuration.GetConnectionString("CoordinatesConnectionString");
        serviceCollection.AddDbContext<CoordinatesDbContext>(x => x.UseSqlServer(connectionString));
        serviceCollection.AddScoped<ICoordinatesRepository, CoordinatesRepository>();
        serviceCollection.AddScoped<ICoordinatesService, CoordinatesService>();
        return serviceCollection;
    }
}