namespace Sofomo.Forecast;

internal class ForecastService : IForecastService
{
    private readonly IForecastRepository _forecastRepository;

    public ForecastService(IForecastRepository forecastRepository)
    {
        _forecastRepository = forecastRepository;
    }

    public async Task<ForecastDto> AddForecast(ForecastDto forecast)
    {
        var forecastEntity = new Forecast(forecast.Temperature, forecast.Time, forecast.Latitude, forecast.Longitude);

        var createdEntityId = await _forecastRepository.AddForecast(forecastEntity);

        if (createdEntityId == -1)
        {
            return null;
        }

        return new ForecastDto(createdEntityId, forecast.Temperature, forecast.Time, forecast.Latitude, forecast.Longitude);
    }

    public async Task<IEnumerable<ForecastDto>> GetByCoordinates(double longitude, double latitude)
    {
        var forecastEntities = await _forecastRepository.GetByCoordinatesAsync(latitude, longitude);

        return forecastEntities.Select(i => new ForecastDto(i.Temperature, i.Time, i.Longitude, i.Latitude));
    }
}
