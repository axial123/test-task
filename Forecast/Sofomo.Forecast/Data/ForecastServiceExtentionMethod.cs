using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Sofomo.Forecast.Data
{
    public static class ForecastServiceExtentionMethod
    {
        public static IServiceCollection AddForecastService(this IServiceCollection serviceCollection, IConfigurationManager configuration)
        {
            var connectionString = configuration.GetConnectionString("ForecastConnectionString");
            serviceCollection.AddDbContext<ForecastDbContext>(x => x.UseSqlServer(connectionString));
            serviceCollection.AddScoped<IForecastRepository, ForecastRepository>();
            serviceCollection.AddScoped<IForecastService, ForecastService>();
            return serviceCollection;
        }
    }
}
