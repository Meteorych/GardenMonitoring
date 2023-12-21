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
        public DbSet<Sensor> Sensor { get; set; } = default!;
        public DbSet<Settings> Settings { get; set; } = default!;
		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Settings>().HasData(new Settings()
            {
						Id = 1,
			            MaxHumidity = 85,
			            MinHumidity = 65,
			            MinLight = 2500,
			            MaxLight = 3500,
			            MinPressure = 730,
			            MaxPressure = 900,
			            MinTemperature = 20,
			            MaxTemperature = 30
		    }
            
            );

        }
        
	}
}
