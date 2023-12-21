using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Authorization;

namespace GardenMonitoring.Models
{
    [Authorize]
    public class PlantState
    {
	    [Key]
	    public int PlantId { get; set; }

	    [ForeignKey("PlantId")]
		public Plant Plant { get; set; }
        public DateTime TimeStamp { get; set; }
        public int Temperature { get; set; }
        public int Light { get; set; }
        public int Pressure { get; set;}
        public int Humidity { get; set;}
    }
}
