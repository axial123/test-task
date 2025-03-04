namespace Sofomo.Coordinates;

internal interface ICoordinatesService
{
    IEnumerable<CoordinatesDto> GetCoordinates();
}