using Microsoft.EntityFrameworkCore;
using Sofomo.Forecast.Data;

namespace Sofomo.Forecast;

internal class ForecastRepository : IForecastRepository
{
    private readonly ForecastDbContext _forecastDbContext;

    public ForecastRepository(ForecastDbContext forecastDbContext)
    {
        _forecastDbContext = forecastDbContext;
    }

    public async Task<int> AddForecast(Forecast forecast)
    {
        var existingForecast = await _forecastDbContext.Forecast.SingleOrDefaultAsync(i => i.Latitude == forecast.Latitude && i.Longitude == forecast.Longitude && i.Time == forecast.Time);
    
        if (existingForecast is null)
        {
            await _forecastDbContext.AddAsync<Forecast>(forecast);
            await _forecastDbContext.SaveChangesAsync();

            return forecast.Id;
        }

        return -1;
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
