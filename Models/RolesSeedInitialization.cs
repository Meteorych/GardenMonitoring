using Microsoft.AspNetCore.Identity;

namespace GardenMonitoring.Models
{
	public static class RolesSeedInitialization
	{
		public static async void Initialize(IServiceProvider serviceProvider)
		{
			using var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
			if (roleManager?.Roles == null)
			{
				throw new ArgumentNullException(nameof(roleManager), "Null roles logic context!");
			}
			var roles = new[] { "Agronomist", "Agricultural" };

			foreach (var roleName in roles)
			{
				var roleExists = roleManager.RoleExistsAsync(roleName).Result;
				if (!roleExists)
				{
					var role = new IdentityRole(roleName);
					await roleManager.CreateAsync(role);
				}
			}
		}
	}
}
