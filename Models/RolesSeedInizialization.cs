using GardenMonitoring.Data;
using Microsoft.EntityFrameworkCore;

namespace GardenMonitoring.Models
{
	public class RolesSeedInizialization
	{
		public static void Initialize(IServiceProvider serviceProvider)
		{
			using var context = new ApplicationDbContext(
				serviceProvider.GetRequiredService<
					DbContextOptions<ApplicationDbContext>>());
			if (context?.Roles == null)
			{
				throw new ArgumentNullException(nameof(context), "Null roles logic context!");
			}

			if (context.Roles.Any())
			{
				return;
			}


		}
	}
}
