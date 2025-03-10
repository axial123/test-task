namespace Sofomo.Forecast;

public class ForecastDto
{
    public int Id { get; set; }
    public double Temperature { get; set; }
    public DateTime Time { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public ForecastDto(double temperature, DateTime time, double latitude, double longitude)
    {
        Temperature = temperature;
        Time = time;
        Latitude = latitude;
        Longitude = longitude;
    }

    public ForecastDto(int id, double temperature, DateTime time, double latitude, double longitude)
    {
        Id = id;
        Temperature = temperature;
        Time = time;
        Latitude = latitude;
        Longitude = longitude;
    }
}
