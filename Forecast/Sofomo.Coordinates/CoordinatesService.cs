namespace Sofomo.Coordinates;

internal class CoordinatesService : ICoordinatesService
{
    private readonly ICoordinatesRepository _repository;

    public CoordinatesService(ICoordinatesRepository repository)
    {
        _repository = repository;
    }

    public async Task AddCoordinates(CoordinatesDto coordinates)
    {
        var coordinatesEntity = new Coordinates(coordinates.Latitude, coordinates.Longitude);
        await _repository.AddAsync(coordinatesEntity);
        await _repository.SaveChangesAsync();

    }

    public async Task DeleteCoordinates(string id)
    {
        var coordinates = await _repository.GetByIdAsync(id);

        if (coordinates is not null)
        {
            await _repository.DeleteAsync(coordinates);
            await _repository.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<CoordinatesDto>> GetAllCoordinates()
    {
        var bookEntities = await _repository.GetAllAsync();
        var books = bookEntities.Select(x => new CoordinatesDto(x.Id, x.Latitude, x.Longitude));

        return books;
    }
}
