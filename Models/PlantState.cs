using Microsoft.AspNetCore.Authorization;

namespace GardenMonitoring.Models
{
    [Authorize]
    public class PlantState
    {
        public int Id { get; set; }
        public int PlantId { get; set; }
        public Plant Plant { get; set; }
        public DateTime TimeStamp { get; set; }
        public int Temperature { get; set; }
        public int Light { get; set; }
        public int Pressure { get; set;}
        public int Humidity { get; set;}
    }
}
