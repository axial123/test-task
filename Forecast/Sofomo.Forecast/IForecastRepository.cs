using Microsoft.EntityFrameworkCore;
using Sofomo.Forecast.Data;

namespace Sofomo.Forecast;

interface IForecastRepository
{
    Task<IEnumerable<Forecast>> GetByCoordinatesAsync(double latitude, double longitude);
    Task SaveChangesAsync();
}

internal class ForecastRepository : IForecastRepository
{
    private readonly ForecastDbContext _forecastDbContext;

    public ForecastRepository(ForecastDbContext forecastDbContext)
    {
        _forecastDbContext = forecastDbContext;
    }

    public async Task<IEnumerable<Forecast>> GetByCoordinatesAsync(double latitude, double longitude)
    {
        return await _forecastDbContext.Forecast.Where(i => i.Latitude == latitude && i.Longitude == longitude)
                             .OrderByDescending(i => i.Time)
                             .ToListAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _forecastDbContext.SaveChangesAsync();
    }
}
