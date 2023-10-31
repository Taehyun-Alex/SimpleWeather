namespace SimpleWeather.Pages;

public partial class SearchPage : ContentPage
{
	private List<string> cityNames = new List<string>
	{
		"London",
		"Perth",
		"Seoul",
		"Tokyo"
	};
	public SearchPage()
	{
		InitializeComponent();
		cityListView.ItemsSource = cityNames;
	}

    private void gobackButton_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("..");
    }

    private async void cityListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item is string selectedCity)
        {
            // Update the API address with the selected city name
            App.ApiUrl = $"https://pro.openweathermap.org/data/2.5/forecast/hourly?q={selectedCity}&appid=59a4ade3192313d407110c1eb429f1a8&units=metric&cnt=10";

            await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
        }
    }
}