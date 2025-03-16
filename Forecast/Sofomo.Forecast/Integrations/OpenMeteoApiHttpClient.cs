namespace Sofomo.Forecast.Integrations;

public class OpenMeteoApiHttpClient
{
    private readonly HttpClient _httpClient;

    public OpenMeteoApiHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
}
