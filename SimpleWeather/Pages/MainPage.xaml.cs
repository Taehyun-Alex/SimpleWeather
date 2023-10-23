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
}