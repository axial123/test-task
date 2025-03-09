namespace Sofomo.Coordinates.Endpoints;

public class GetAllCoordinatesResponse
{
    public IEnumerable<CoordinatesDto> Coordinates { get; init; }
}
