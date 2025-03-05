using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection;

namespace Sofomo.Coordinates;

internal class Coordinates
{
    public string Id{ get; }
    public double Latitude { get; }
    public double Longitude { get; }

    public Coordinates(double latitude, double longitude)
    {
        Latitude=Guard.Against.NegativeOrZero(latitude);
        Longitude= Guard.Against.NegativeOrZero(longitude);
        Id = latitude.ToString() + longitude.ToString();
    }
}

public class CoordinatesDbContext : DbContext
{
    internal DbSet<Coordinates> Coordinates { get; set; }

    public CoordinatesDbContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Coordinates");
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}

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



