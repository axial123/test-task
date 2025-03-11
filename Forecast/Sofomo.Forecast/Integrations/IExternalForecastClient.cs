namespace Sofomo.Forecast.Integrations;

internal interface IExternalForecastClient
{
    Task<OpenMeteoDto?> FetchForecastAsync(double latitude, double longitude);
}