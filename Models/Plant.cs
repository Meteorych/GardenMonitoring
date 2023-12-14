using Microsoft.AspNetCore.Authorization;
using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;

namespace GardenMonitoring.Models
{
    [Authorize]
    public class Plant
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [NotMapped]
        public Dictionary<string, string>? Info { get; set; }
        public int ClassId { get; set; }
    }
}
