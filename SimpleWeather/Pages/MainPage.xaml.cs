namespace SimpleWeather.Pages;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    private void menuButton_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync(nameof(SettingPage));
    }

    private async void searchButton_Clicked(object sender, EventArgs e)
    {
        //Shell.Current.GoToAsync(nameof(SearchPageView));
        //List<string> temps = await WeatherAPIService.GetTemp();
        //string tempsString = string.Join(", ", temps);

        //// Assign the concatenated string to perthcity.Text
        //perthcity.Text = tempsString;
    }
    
    private void favButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(FavouritesPage));
    }
}