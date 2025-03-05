namespace Sofomo.Coordinates;

internal interface ICoordinatesService
{
    Task<IEnumerable<CoordinatesDto>> GetAllCoordinates();
    Task AddCoordinates(CoordinatesDto coordinates);
    Task DeleteCoordinates(string id);
}