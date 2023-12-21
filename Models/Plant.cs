using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Build.Framework;

namespace GardenMonitoring.Models
{
    public class Plant
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string? Info { get; set; }
        public int ClassId { get; set; }
        public PlantClass Class { get; set; }
    }
}
