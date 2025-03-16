using Ardalis.GuardClauses;

namespace Sofomo.Coordinates;

internal class Coordinates
{
    public string Id { get; }
    public double Latitude { get; }
    public double Longitude { get; }

    public Coordinates(double latitude, double longitude)
    {
        Latitude = Guard.Against.OutOfRange(latitude, nameof(latitude), -90, 90);
        Longitude = Guard.Against.OutOfRange(longitude, nameof(longitude), -180, 180);
        Id = latitude.ToString() + longitude.ToString();
    }
}