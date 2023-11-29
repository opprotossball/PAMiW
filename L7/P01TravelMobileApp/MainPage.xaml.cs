using P01TravelMobileApp.ViewModels;

namespace P01TravelMobileApp
{
	public partial class MainPage : ContentPage
	{

		public MainPage(FlightsViewModel flightsViewModel)
		{
			BindingContext = flightsViewModel;
			InitializeComponent();
		}
	}

}
