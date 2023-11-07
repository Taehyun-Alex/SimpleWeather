
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

        public bool IsFavorite { get; set; }
    }

    public List<FavCityItem> favCities = new List<FavCityItem> //manual list of favourite cities.
    {
        new FavCityItem { CityName = "London", ImageSource = "empty_loveheart.png", IsFavorite = false },
        new FavCityItem { CityName = "Perth", ImageSource = "empty_loveheart.png", IsFavorite = false },
        new FavCityItem { CityName = "Seoul", ImageSource = "empty_loveheart.png", IsFavorite = false },
        new FavCityItem { CityName = "Tokyo", ImageSource = "empty_loveheart.png", IsFavorite = false }
    };

    private void xButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        //var favCity = favCities.FirstOrDefault(c => c.CityName == "Perth"); // Replace with the city you want to toggle
        //if (favCity != null)
        //{
        //    favCity.IsFavorite = !favCity.IsFavorite;
        //    favCity.ImageSource = favCity.IsFavorite ? "filled_loveheart.png" : "empty_loveheart.png";
        //}
    }
}