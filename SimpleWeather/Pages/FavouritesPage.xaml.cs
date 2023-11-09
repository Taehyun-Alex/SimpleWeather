using SimpleWeather.Models;
namespace SimpleWeather.Pages;

public partial class FavouritesPage : ContentPage
{
	public FavouritesPage()
	{
		InitializeComponent();
        List<CityData.FavCityItem> favCities = CityData.FavCities;
        favCityView.ItemsSource = favCities;
    }

    private void xButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
    }
}