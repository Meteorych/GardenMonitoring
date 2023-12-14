using GardenMonitoring.Data;
using Humanizer.Localisation;
using Microsoft.EntityFrameworkCore;

namespace GardenMonitoring.Models
{
    public class PlantSeedInizialization
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new PlantContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<PlantContext>>());
            if (context?.Plant == null)
            {
                throw new ArgumentNullException(nameof(context), "Null movie logic context!");
            }

            // Look for any movies.
            if (context.Plant.Any() && context.PlantState.Any() && context.PlantClass.Any())
            {
                return; // DB has been seeded
            }

            if (!context.Plant.Any())
            {
	            context.Plant.AddRange(
		            new Plant
		            {
			            Name = "Potato",
			            ClassId = 1,
		            },

		            new Plant
		            {
			            Name = "Tomato",
			            ClassId = 1,
		            },
		            new Plant
		            {
			            Name = "Rose",
			            ClassId = 2,
		            }
	            );
			}

            if (!context.PlantClass.Any())
            {
	            context.PlantClass.AddRange(
		            new PlantClass
		            {
			            Name = "Food Culture"
		            },
		            new PlantClass
		            {
			            Name = "Flower"
		            }

	            );
			}

            if (!context.PlantState.Any())
            {
	            context.PlantState.AddRange(
		            new PlantState
		            {
			            Humidity = 87,
			            Light = 56,
			            PlantId = 1,
			            Pressure = 12,
			            Temperature = 27,
			            TimeStamp = DateTime.Now

		            },
		            new PlantState
		            {
			            Humidity = 85,
			            Light = 37,
			            PlantId = 2,
			            Pressure = 15,
			            Temperature = 27,
			            TimeStamp = new DateTime(2023, 12, 13, 12, 45, 59)
		            }
	            );
			}
            context.SaveChanges();
        }
    }

}
