namespace Sofomo.Forecast;

internal interface IForecastService
{
    Task<IEnumerable<ForecastDto>> GetByCoordinates(double longitude, double latitude);
    Task<ForecastDto> AddForecast(ForecastDto forecast);
}
