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
                throw new ArgumentNullException(nameof(context), "Null plants logic context!");
            }

            
            if (context.Plant.Any() && context.PlantState.Any() && context.PlantClass.Any() && context.Settings.Any())
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
	            var dateStart = new DateTime(2023, 09, 23);
	            context.PlantState.AddRange(
		            new PlantState
		            {
			            Humidity = 87,
			            Light = 56,
			            PlantId = 1,
			            Pressure = 12,
			            Temperature = 27,
			            TimeStamp = dateStart.AddDays(new Random().Next((DateTime.Now - dateStart).Days))

		            },
		            new PlantState
		            {
			            Humidity = 85,
			            Light = 37,
			            PlantId = 2,
			            Pressure = 15,
			            Temperature = 27,
						TimeStamp = dateStart.AddDays(new Random().Next((DateTime.Now - dateStart).Days))
					}
	            );
			}

            if (!context.Settings.Any())
            {
	            context.Settings.AddRange(
		            new Settings
		            {
			            MaxHumidity = 85,
						MinHumidity = 65,
			            MinLight = 2500,
						MaxLight = 3500,
			            MinPressure = 730,
						MaxPressure = 900,
			            MinTemperature = 20,
						MaxTemperature = 30
		            }
	            );

            }
            context.SaveChanges();
        }
    }

}
