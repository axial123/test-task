using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Sofomo.Forecast.Data;

public class ForecastDbContext : DbContext
{
    internal DbSet<Forecast> Forecast { get; set; }

    public ForecastDbContext(DbContextOptions<ForecastDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Forecast");
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.Entity<Forecast>().HasKey(f => f.Id);
        modelBuilder.Entity<Forecast>().Property(f => f.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Forecast>().HasIndex(x => new { x.Latitude, x.Longitude, x.Time }).IsUnique();
    }
}
