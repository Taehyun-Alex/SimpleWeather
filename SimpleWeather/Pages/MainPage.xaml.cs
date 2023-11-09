using SimpleWeather.Models;

namespace SimpleWeather.Pages;

public partial class MainPage : ContentPage
{
    public List<Models.ApiModels.List> WeatherList;
    private string city;
    private bool isCitySet = false; //set this boolean to see if the city has been set.

    public MainPage()
	{
		InitializeComponent();
        WeatherList = new List<Models.ApiModels.List>();
    }

    private void menuButton_Clicked(object sender, EventArgs e)
    {
        SettingPage settingPage = new SettingPage();
        Navigation.PushAsync(settingPage);
    }
    
    
    private void favButton_Clicked(object sender, EventArgs e)
    {
        var cityNameToToggle = "Perth"; // Replace with the city you want to toggle

        // Find the city in the favorite cities list based on the cityNameToToggle
        var favCity = CityData.FavCities.FirstOrDefault(c => c.CityName == cityNameToToggle);

        if (favCity != null)
        {
            favCity.IsFavorite = !favCity.IsFavorite;

            // Update the source of the favButton based on the boolean value
            favButton.Source = favCity.IsFavorite ? "full_loveheart.svg" : "empty_loveheart.svg";
        }

        FavouritesPage favPage = new FavouritesPage();
        Navigation.PushAsync(favPage);
    }

    private void searchButton_Clicked(object sender, EventArgs e)
    {
        SearchPage searchPage = new SearchPage(this);
        Navigation.PushAsync(searchPage);
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        if (!isCitySet) // if the city has not set yet, the default will be Perth.
        {
            await GetLocationByCity("Perth");
            isCitySet = true; // Mark the city as set
        }
    }

    public async Task GetLocationByCity(string city)
    {
        this.city = city;
        var result = await WeatherAPIService.GetWeatherInformation(city);
        WeatherList.Clear();
        foreach (var item in result.list)
        {
            item.ImageSource = item.weather[0].customIcon;
            WeatherList.Add(item);
        }
        CvWeather.ItemsSource = null;
        CvWeather.ItemsSource = WeatherList;

        temp_label.Text = Math.Round(result.list[0].main.temp).ToString() + "°C";
        humid_label.Text = result.list[0].main.humidity.ToString() + "% humid";
        time_label.Text = result.list[0].currentTime.ToString("hh:mm tt");
        time_label2.Text = result.list[0].currentTime.ToString("dddd\n dd MMM yyyy");
        city_label.Text = result.city.name;
        initial_weather_icon.Source = result.list[0].weather[0].customIcon;

    }

}