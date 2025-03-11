using System.Net.Http.Json;

namespace Sofomo.Forecast.Integrations;

internal class ExternalForecastClient : IExternalForecastClient
{
    private readonly HttpClient _httpClient;

    public ExternalForecastClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<OpenMeteoDto?> FetchForecastAsync(double latitude, double longitude)
    {
        var response = await _httpClient.GetAsync($"forecast?latitude={latitude}&longitude={longitude}&current=temperature_2m");
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<OpenMeteoDto>();
    }
}
