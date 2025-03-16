using Sofomo.Forecast.Data;

namespace Sofomo.Forecast;

interface IForecastRepository
{
    Task<IEnumerable<Forecast>> GetByCoordinatesAsync(double latitude, double longitude);
    Task<IEnumerable<Forecast>> GetByCoordinatesAndDateAsync(DateTime date, double latitude, double longitude);
    Task<AddForecastResult> AddForecast(Forecast forecast);
    Task SaveChangesAsync();
}