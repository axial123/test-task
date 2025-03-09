using Microsoft.EntityFrameworkCore;

namespace Sofomo.Coordinates.Data;

internal class CoordinatesRepository : ICoordinatesRepository
{
    private readonly CoordinatesDbContext _coordinatesDbContext;

    public CoordinatesRepository(CoordinatesDbContext coordinatesDbContext)
    {
        _coordinatesDbContext = coordinatesDbContext;
    }

    public Task AddAsync(Coordinates coordinates)
    {
        _coordinatesDbContext.Add(coordinates);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Coordinates coordinates)
    {
        _coordinatesDbContext.Remove(coordinates);
        return Task.CompletedTask;
    }

    public async Task<IEnumerable<Coordinates>> GetAllAsync()
    {
        return await _coordinatesDbContext.Coordinates.ToListAsync();
    }

    public async Task<Coordinates> GetByIdAsync(string id)
    {
        return await _coordinatesDbContext.Coordinates.FindAsync(id);
    }

    public async Task SaveChangesAsync()
    {
        await _coordinatesDbContext.SaveChangesAsync();
    }
}