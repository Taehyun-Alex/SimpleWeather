namespace SimpleWeather.Pages;

public partial class FavouritesPage : ContentPage
{
	public FavouritesPage()
	{
		InitializeComponent();
        favCityView.ItemsSource = favCities;
    }

    public class FavCityItem //create a class with properties so we can bind it to xaml colletionview.
    {
        public string CityName { get; set; }
        public string ImageSource { get; set; }
    }

    private List<FavCityItem> favCities = new List<FavCityItem> //manual list of favourite cities.
    {
        new FavCityItem { CityName = "London", ImageSource = "empty_loveheart.png" },
        new FavCityItem { CityName = "Perth", ImageSource = "empty_loveheart.png" },
        new FavCityItem { CityName = "Seoul", ImageSource = "empty_loveheart.png" },
        new FavCityItem { CityName = "Tokyo", ImageSource = "empty_loveheart.png" }
    };

    private void xButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

}