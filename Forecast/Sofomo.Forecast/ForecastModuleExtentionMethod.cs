using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Sofomo.Forecast.Integrations;
using Sofomo.Forecast.Data;

namespace Sofomo.Forecast;

public static class ForecastModuleExtentionMethod
{
    public static IServiceCollection AddForecastModule(this IServiceCollection serviceCollection, IConfigurationManager configuration)
    {
        var connectionString = configuration.GetConnectionString("ForecastConnectionString");
        serviceCollection.AddDbContext<ForecastDbContext>(x => x.UseSqlServer(connectionString));
        serviceCollection.AddScoped<IForecastRepository, ForecastRepository>();
        serviceCollection.AddScoped<IForecastService, ForecastService>();

        serviceCollection.AddHttpClient<IExternalForecastClient, ExternalForecastClient>((sp, client) =>
        {
            var config = sp.GetRequiredService<IConfiguration>();
            var baseUrl = config["ForecastProvider:Url"];
            client.BaseAddress = new Uri(baseUrl);
        });

        return serviceCollection;
    }
}