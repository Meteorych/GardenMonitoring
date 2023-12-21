using GardenMonitoring.Data;
using Microsoft.EntityFrameworkCore;

namespace GardenMonitoring.Models
{
    public class PlantSeedInitialization
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

            
            if (context.Plant.Any() && context.PlantState.Any() && context.PlantClass.Any() && context.Sensor.Any())
            {
                return; // DB has been seeded
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
	            context.SaveChanges();
            }
			

			if (!context.Plant.Any())
            {
	            context.Plant.AddRange(
		            new Plant
		            {
			            Name = "Potato",
						Info = "Potatoes are starchy tuberous crops from the perennial Solanum tuberosum of the nightshade family (Solanaceae). They're one of the world's most widely grown and consumed vegetables, known for their versatility, nutritional value, and ability to thrive in various climates.",
			            ClassId = 1
		            },

		            new Plant
		            {
			            Name = "Tomato",
						Info = "Tomatoes, scientifically known as Solanum lycopersicum, originate from western South America. Initially cultivated by indigenous peoples in the Andes, they found their way to Europe through Spanish explorers in the 16th century. From there, they spread globally.\r\n" +
						       "Tomatoes come in various types differing in size, shape, color, and flavor. You'll find beefsteak, cherry, grape, plum, and heirloom tomatoes among the many varieties. They range from small, sweet cherry tomatoes to larger, meaty beefsteak types.\r\n" +
						       "In terms of nutrition, tomatoes pack a punch. They're rich in vitamins, especially vitamin C and vitamin K. Additionally, they contain potassium, folate, and antioxidants such as lycopene. Lycopene, responsible for the red color of tomatoes, is linked to various health benefits, including heart health and potentially reducing certain cancer risks.",
			            ClassId = 1
		            },
		            new Plant
		            {
			            Name = "Rose",
						Info ="The rose (genus Rosa) is a flowering plant species revered for its beauty, fragrance, and diverse variations.\r\n" +
						      "Roses, believed to have originated millions of years ago, belong to the Rosaceae family and encompass hundreds of species and thousands of cultivars. They are woody perennial plants, often armed with prickles along their stems. The flowers typically have five petals, though some species can have more, arranged symmetrically around a central point. Roses can range in size from low-growing ground cover roses to towering climbers.",
			            ClassId = 2
		            }
	            );
	            context.SaveChanges();
			}

            if (!context.PlantState.Any())
            {
	            var dateStart = new DateTime(2023, 09, 23);
	            context.PlantState.AddRange(
		            new PlantState
		            {
			            Humidity = 87,
			            Light = 3800,
			            PlantId = 1, 
			            Pressure = 780,
			            Temperature = 27,
			            TimeStamp = dateStart.AddSeconds(new Random().Next((int)(DateTime.Now - dateStart).TotalSeconds))

		            },
		            new PlantState
		            {
			            Humidity = 83,
			            Light = 3700,
			            PlantId = 2,
			            Pressure = 750,
			            Temperature = 27,
						TimeStamp = dateStart.AddSeconds(new Random().Next((DateTime.Now - dateStart).Seconds))
					}
	            );
			}

            if (!context.Sensor.Any())
            {
	            context.Sensor.AddRange(
					new Sensor
					{
						SensorState = true,
						SensorType = "temperature sensor"
					},
					new Sensor
					{
						SensorState = true,
						SensorType = "pressure meter"
					},
					new Sensor
					{
						SensorState = false,
						SensorType = "humidity sensor"
					},
					new Sensor
					{
						SensorState = true,
						SensorType = "light sensor"
					}
				);
            }

            context.SaveChanges();
        }
    }

}
