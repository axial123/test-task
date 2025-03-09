using Ardalis.GuardClauses;

namespace Sofomo.Coordinates;

internal class Coordinates
{
    public string Id{ get; }
    public double Latitude { get; }
    public double Longitude { get; }

    public Coordinates(double latitude, double longitude)
    {
        Latitude=Guard.Against.NegativeOrZero(latitude);
        Longitude= Guard.Against.NegativeOrZero(longitude);
        Id = latitude.ToString() + longitude.ToString();
    }
}



