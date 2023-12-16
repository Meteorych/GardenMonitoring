using Microsoft.AspNetCore.Authorization;
using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Build.Framework;

namespace GardenMonitoring.Models
{
    [Authorize(Roles = "Agronomist")]
    public class Plant
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string? Info { get; set; }
        public int ClassId { get; set; }
    }
}
