using P01TravelMobileApp.ViewModels;

namespace P01TravelMobileApp;

public partial class FlightDetailsView : ContentPage
{
	public FlightDetailsView(FlightDetailsViewModel flightDetailsViewModel)
	{
		BindingContext = flightDetailsViewModel;
		InitializeComponent();
	}
}