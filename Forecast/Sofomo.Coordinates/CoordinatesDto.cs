namespace Sofomo.Coordinates;

public struct CoordinatesDto
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
}