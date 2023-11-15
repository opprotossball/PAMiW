using System;

namespace P04WeatherForecastAPI.Client
{
	public class TemperatureConvert
	{
		public static double F2C(double temperatureF)
		{
			return Math.Round((temperatureF - 32.0) / 1.8);
		}
	}
}
