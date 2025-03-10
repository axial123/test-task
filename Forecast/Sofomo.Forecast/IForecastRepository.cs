namespace Sofomo.Forecast;

interface IForecastRepository
{
    Task<IEnumerable<Forecast>> GetByCoordinatesAsync(double latitude, double longitude);
    Task<int> AddForecast(Forecast forecast);
    Task SaveChangesAsync();
}