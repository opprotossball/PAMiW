namespace P03Travel.Shared.Coverters
{
	public class TemperatureConverter
	{
		public static double F2C(double farenheit)
		{
			return (farenheit - 32) / 1.8;
		}
	}
}
