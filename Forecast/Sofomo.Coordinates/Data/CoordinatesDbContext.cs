using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Sofomo.Coordinates.Data;

public class CoordinatesDbContext : DbContext
{
    internal DbSet<Coordinates> Coordinates { get; set; }

    public CoordinatesDbContext(DbContextOptions<CoordinatesDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Coordinates");
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.Entity<Coordinates>().HasKey(e => e.Id);
    }
}



