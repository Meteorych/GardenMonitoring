﻿namespace GardenMonitoring.Models
{
	public class Settings
	{
		public int Id { get; set; }
		public int MaxTemperature { get; set; }
		public int MinTemperature { get; set; }

		public int MaxLight { get; set; }
		public int MinLight { get; set; }

		public int MaxPressure { get; set; }
		public int MinPressure { get; set; }

		public int MaxHumidity { get; set; }
		public int MinHumidity { get; set; }
	}
}

