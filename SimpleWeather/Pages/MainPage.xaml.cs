

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

    
    private void favButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(FavouritesPage));
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        var result = await WeatherAPIService.GetWeatherInformation();
        temp_label.Text = result.list[0].main.temp.ToString();
    }
}