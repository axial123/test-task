using FastEndpoints;
using FastEndpoints.Testing;
using FluentAssertions;
using Sofomo.Coordinates.Endpoints;

namespace Sofomo.Coordinates.Tests;

public class CooridnatsModuleTests(Fixture fixture): TestBase<Fixture>
{
    [Fact]
    public async Task GetAll_ShouldReturnAllCoordinates()
    {
        // arrange 
        // act
        var result = await fixture.Client.GETAsync<GetAll, GetAllCoordinatesResponse>();

        // assert
        result.Response.EnsureSuccessStatusCode();
        result.Result.Coordinates.ToList().Count.Should().Be(3);
    }
}
