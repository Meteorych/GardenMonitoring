using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public DbSet<GardenMonitoring.Models.Plant> Plant { get; set; } = default!;
        public DbSet<GardenMonitoring.Models.PlantClass> PlantClass { get; set; } = default!;
        public DbSet<GardenMonitoring.Models.PlantState> PlantState { get; set; } = default!;
    }
}
