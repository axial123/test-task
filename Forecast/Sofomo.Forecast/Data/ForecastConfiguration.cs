using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Sofomo.Forecast.Data
{
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
            yield return new Forecast
            {
                Id = 1,
                Latitude = 37.7749,
                Longitude = -122.4194,
                Time = new DateTime(2025, 3, 10, 12, 0, 0), // Example DateTime (UTC)
                Temperature = 18.5
            };
            yield return new Forecast
            {
                Id = 2,
                Latitude = 40.7128,
                Longitude = -74.0060,
                Time = new DateTime(2025, 3, 10, 15, 0, 0),
                Temperature = 12.3
            };
            yield return new Forecast
            {
                Id = 3,
                Latitude = 51.5074,
                Longitude = -0.1278,
                Time = new DateTime(2025, 3, 10, 9, 30, 0),
                Temperature = 10.0
            };
        }
    }
}
