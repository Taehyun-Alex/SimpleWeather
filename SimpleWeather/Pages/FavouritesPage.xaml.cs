using SimpleWeather.Models;
namespace SimpleWeather.Pages;

public partial class FavouritesPage : ContentPage
{
	public FavouritesPage()
	{
		InitializeComponent();
        List<CityData.FavCityItem> favCities = CityData.FavCities.Where(c => c.IsFavorite).ToList(); //make a list of cities that has true boolean value.
        favCityView.ItemsSource = favCities;
    }

    private void xButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        if (sender is ImageButton imageButton && imageButton.BindingContext is CityData.FavCityItem favCityItem)
        {
            // Toggle the IsFavorite property
            favCityItem.IsFavorite = !favCityItem.IsFavorite;

            // Update the source of the ImageButton based on the boolean value
            imageButton.Source = favCityItem.IsFavorite ? "full_loveheart.svg" : "empty_loveheart.svg";
            
            favCityItem.SaveToPreferences();
         }
    }

}