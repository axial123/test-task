namespace Sofomo.Coordinates;

internal interface ICoordinatesService
{
    Task<IEnumerable<CoordinatesDto>> GetAllCoordinates();
    Task<CoordinatesDto?> GetCoordinatesById(string id);
    Task AddCoordinates(CoordinatesDto coordinates);
    Task DeleteCoordinates(string id);
}