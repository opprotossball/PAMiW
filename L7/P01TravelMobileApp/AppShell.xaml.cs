namespace P01TravelMobileApp
{
	public partial class AppShell : Shell
	{
		public AppShell()
		{
			InitializeComponent();
			Routing.RegisterRoute(nameof(FlightDetailsView), typeof(FlightDetailsView));
		}
	}
}
