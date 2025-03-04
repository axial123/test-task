namespace Sofomo.Coordinates;

public struct CoordinatesDto
{
    public double Latitude { get; }
    public double Longitude { get; }

    public CoordinatesDto(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }
}