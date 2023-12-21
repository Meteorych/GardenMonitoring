using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;

namespace GardenMonitoring.Models
{
    [Authorize]
    public class PlantClass
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
