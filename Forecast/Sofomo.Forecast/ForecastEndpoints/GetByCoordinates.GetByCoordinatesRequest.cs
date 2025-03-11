namespace Sofomo.Forecast.ForecastEndpoints;

public class GetByCoordinatesRequest
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public DateTime? Date { get; set; }
}
