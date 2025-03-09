using FastEndpoints.Testing;
using Xunit.Sdk;

namespace Sofomo.Coordinates.Tests;

public class Fixture(IMessageSink messageSink) : AppFixture<Program>
{
    protected override ValueTask SetupAsync()
    {
        Client = CreateClient();

        return ValueTask.CompletedTask;
    }

    protected override ValueTask TearDownAsync()
    {
        Client.Dispose();
        return base.TearDownAsync();
    }
}
