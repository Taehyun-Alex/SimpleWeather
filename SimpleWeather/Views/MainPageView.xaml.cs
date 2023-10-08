namespace SimpleWeather.Views;

public partial class MainPageView : ContentPage
{
	public MainPageView()
	{
		InitializeComponent();
	}

    private void menuButton_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync(nameof(SettingPageView));
    }

    private void searchButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(SearchPageView));
    }

    private void favButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(FavouritesPageView));
    }
}