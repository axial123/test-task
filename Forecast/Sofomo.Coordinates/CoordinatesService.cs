namespace Sofomo.Coordinates;

internal class CoordinatesService : ICoordinatesService
{
    public List<CoordinatesDto> GetCoordinates()
    {
        return new List<CoordinatesDto>()
        {
            new CoordinatesDto(51.1172642,17.0215266),
            new CoordinatesDto(51.097800, 17.032707),
            new CoordinatesDto(51.1075504,17.0690172)
        };
    }
}
