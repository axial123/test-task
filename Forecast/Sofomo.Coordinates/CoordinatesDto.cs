namespace Sofomo.Coordinates;

public class CoordinatesDto
{
    public double Latitude { get; }
    public double Longitude { get; }
    public string Id { get; }

    public CoordinatesDto(string id, double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
        Id = id;
    }

    public CoordinatesDto(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
        Id = latitude.ToString() + longitude.ToString();
    }
    public CoordinatesDto()
    {

    }
}