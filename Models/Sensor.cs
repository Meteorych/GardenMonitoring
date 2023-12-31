﻿using Microsoft.AspNetCore.Authorization;

namespace GardenMonitoring.Models
{
	[Authorize(Policy = "Require agronomist role")]
	public class Sensor
	{
		public int Id { get; set; }
		public string SensorType { get; set;}
		public bool SensorState { get; set; }
	}
}
