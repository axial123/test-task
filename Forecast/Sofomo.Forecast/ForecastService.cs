
using Sofomo.Forecast.Integrations;

namespace Sofomo.Forecast;

internal class ForecastService : IForecastService
{
    private readonly IForecastRepository _forecastRepository;
    private readonly IExternalForecastClient _forecastClient;

    public ForecastService(IForecastRepository forecastRepository, IExternalForecastClient forecastClient)
    {
        _forecastRepository = forecastRepository;
        _forecastClient = forecastClient;
    }

    public async Task<ForecastDto> AddForecast(ForecastDto forecast)
    {
        var forecastEntity = new Forecast(forecast.Temperature, forecast.Time, forecast.Latitude, forecast.Longitude);

        var result = await _forecastRepository.AddForecast(forecastEntity);

        if (result.IsAdded)
        {
            return new ForecastDto(forecast.Temperature, forecast.Time, forecast.Latitude, forecast.Longitude);
        }

        // handle it gracefully
        return null;
    }

    public async Task<IEnumerable<ForecastDto>> GetByCoordinates(double longitude, double latitude)
    {
        // look up in cache
        // look up in db
        // fetch from api and write to db and cache

        var forecastEntities = await _forecastRepository.GetByCoordinatesAsync(latitude, longitude);

        if (!forecastEntities.Any())
        {
            var forecastFromApi = await _forecastClient.FetchForecastAsync(latitude, longitude);

            // add to db
            // add to cache
            var forecastDto = new ForecastDto(forecastFromApi.Current.Temperature_2m, forecastFromApi.Current.Time, latitude, longitude);

            return new List<ForecastDto>() { forecastDto };
        }

        return forecastEntities.Select(i => new ForecastDto(i.Id, i.Temperature, i.Time, i.Longitude, i.Latitude));
    }

    public async Task<IEnumerable<ForecastDto>> GetByCoordinatesAndDate(DateTime date, double longitude, double latitude)
    {
        var forecastEntities = await _forecastRepository.GetByCoordinatesAndDateAsync(date, latitude, longitude);

        return forecastEntities.Select(i => new ForecastDto(i.Id, i.Temperature, i.Time, i.Longitude, i.Latitude));
    }
}
