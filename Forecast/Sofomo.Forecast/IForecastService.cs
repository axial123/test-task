using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofomo.Forecast
{
    internal interface IForecastService
    {
        Task<IEnumerable<ForecastDto>> GetByCoordinates(double longitude, double latitude);
    }

    internal class ForecastService : IForecastService
    {
        private readonly IForecastRepository _forecastRepository;

        public ForecastService(IForecastRepository forecastRepository)
        {
            _forecastRepository = forecastRepository;
        }

        public async Task<IEnumerable<ForecastDto>> GetByCoordinates(double longitude, double latitude)
        {
            var forecastEntities = await _forecastRepository.GetByCoordinatesAsync(latitude, longitude);

            return forecastEntities.Select(i => new ForecastDto(i.Temperature, i.Time, i.Longitude, i.Latitude));
        }
    }
}
