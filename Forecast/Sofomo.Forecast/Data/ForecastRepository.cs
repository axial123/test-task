using Microsoft.EntityFrameworkCore;

namespace Sofomo.Forecast.Data;

internal class ForecastRepository : IForecastRepository
{
    private readonly ForecastDbContext _forecastDbContext;

    public ForecastRepository(ForecastDbContext forecastDbContext)
    {
        _forecastDbContext = forecastDbContext;
    }

    public async Task<AddForecastResult> AddForecast(Forecast forecast)
    {
        var existingForecast = await _forecastDbContext.Forecast.SingleOrDefaultAsync(i => i.Latitude == forecast.Latitude && i.Longitude == forecast.Longitude && i.Time == forecast.Time);
    
        if (existingForecast is null)
        {
            await _forecastDbContext.AddAsync(forecast);
            await _forecastDbContext.SaveChangesAsync();

            return new AddForecastResult(true, Id: forecast.Id);
        }

        return new AddForecastResult(false);
    }

    public async Task<IEnumerable<Forecast>> GetByCoordinatesAndDateAsync(DateTime date, double latitude, double longitude)
    {
        return await _forecastDbContext.Forecast.Where(i => i.Latitude == latitude && i.Longitude == longitude && i.Time == date)
                             .ToListAsync();
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
