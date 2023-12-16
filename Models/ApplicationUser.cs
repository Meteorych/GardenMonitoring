using Microsoft.AspNetCore.Identity;

namespace GardenMonitoring.Models
{
	public class ApplicationUser : IdentityUser
	{
		public string Role { get; set; }
	}
}
