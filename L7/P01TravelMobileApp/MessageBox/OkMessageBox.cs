using P03Travel.Shared.Messages;


namespace P01TravelMobileApp.MessageBox
{
	internal class OkMessageBox : IMessageBox
	{
		public void ShowMessage(string message)
		{
			Shell.Current.DisplayAlert("Message", message, "OK");
		}
	}
}
