using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Sofomo.Forecast.Data;

internal class ForecastConfiguration : IEntityTypeConfiguration<Forecast>
{
    public void Configure(EntityTypeBuilder<Forecast> builder)
    {
        builder.Property(x => x.Longitude).IsRequired();
        builder.Property(x => x.Latitude).IsRequired();
        builder.Property(x => x.Temperature).IsRequired();
        builder.Property(x => x.Time).IsRequired();

        builder.HasData(GetSample());
    }

    private IEnumerable<Forecast> GetSample()
    {
        yield return new Forecast(18.5, new DateTime(2025, 3, 10, 12, 0, 0), 37.7749, -122.4194) { Id = 1};
        yield return new Forecast(12.3, new DateTime(2025, 3, 10, 15, 0, 0), 40.7128, -74.0060) { Id = 2 };
        yield return new Forecast(0, new DateTime(2025, 3, 10, 9, 30, 0), 51.5074, -0.1278) { Id = 3 };
    }
}
