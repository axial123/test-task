namespace Sofomo.Forecast.ForecastEndpoints;

internal class CreateForecastRequest
{
    public double Temperature { get; set; }
    public DateTime Time { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public CreateForecastRequest(double temperature, DateTime time, double latitude, double longitude)
    {
        Temperature = temperature;
        Time = time;
        Latitude = latitude;
        Longitude = longitude;
    }
}
