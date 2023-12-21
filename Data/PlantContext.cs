using Microsoft.EntityFrameworkCore;
using GardenMonitoring.Models;

namespace GardenMonitoring.Data
{
    public class PlantContext : DbContext
    {
        public PlantContext (DbContextOptions<PlantContext> options)
            : base(options)
        {
        }

        public DbSet<Plant> Plant { get; set; } = default!;
        public DbSet<PlantClass> PlantClass { get; set; } = default!;
        public DbSet<PlantState> PlantState { get; set; } = default!;
        public DbSet<Settings> Settings { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
	        modelBuilder.Entity<Plant>().ToTable("Plant");
	        modelBuilder.Entity<PlantClass>().ToTable("PlantClass");
	        modelBuilder.Entity<PlantState>().ToTable("PlantState");
	        modelBuilder.Entity<Settings>().ToTable("Settings");
        }
        public DbSet<GardenMonitoring.Models.Sensor> Sensor { get; set; } = default!;
	}
}
