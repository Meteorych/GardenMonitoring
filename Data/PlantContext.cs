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
    }
}
