using FastEndpoints;
using FastEndpoints.Testing;
using FluentAssertions;
using Sofomo.Coordinates.Endpoints;

namespace Sofomo.Coordinates.Tests;

public class CooridnatsModuleTests(Fixture fixture): TestBase<Fixture>
{
    [Fact]
    public async Task GetAll_ShouldReturn_AllCoordinates()
    {
        var result = await fixture.Client.GETAsync<GetAll, GetAllCoordinatesResponse>();

        result.Response.EnsureSuccessStatusCode();
        result.Result.Coordinates.ToList().Count.Should().Be(3);
    }
}
