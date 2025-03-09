namespace Sofomo.Coordinates;

internal interface ICoordinatesRepository
{
    Task AddAsync(Coordinates coordinates);
    Task DeleteAsync(Coordinates coordinates);
    Task<IEnumerable<Coordinates>> GetAllAsync();
    Task<Coordinates> GetByIdAsync(string id);
    Task SaveChangesAsync();
}