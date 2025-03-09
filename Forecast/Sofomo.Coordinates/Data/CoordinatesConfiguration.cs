using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sofomo.Coordinates.Data;

internal class CoordinatesConfiguration : IEntityTypeConfiguration<Coordinates>
{
    public void Configure(EntityTypeBuilder<Coordinates> builder)
    {
        builder.Property(x => x.Longitude).IsRequired();
        builder.Property(x => x.Latitude).IsRequired();

        builder.HasData(GetSample());
    }

    private IEnumerable<Coordinates> GetSample()
    {
        yield return new Coordinates(51.1172642, 17.0215266);
        yield return new Coordinates(51.097800, 17.032707);
        yield return new Coordinates(51.1075504, 17.0690172);
    }
}



