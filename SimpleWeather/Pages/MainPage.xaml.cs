using SimpleWeather.Models;

namespace SimpleWeather.Pages;

public partial class MainPage : ContentPage
{
    public List<Models.ApiModels.List> WeatherList;
    public string city;
    private bool isCitySet = false; //set this boolean to see if the city has been set.
    private bool isSwitchToggled;


    public MainPage()
	{
		InitializeComponent();
        WeatherList = new List<Models.ApiModels.List>();
    }

    public MainPage(bool isSwitchToggled)
    {
        this.isSwitchToggled = isSwitchToggled;
    }

    private void menuButton_Clicked(object sender, EventArgs e)
    {
        SettingPage settingPage = new SettingPage(this);
        Navigation.PushAsync(settingPage);
    }
    
    
    private void favButton_Clicked(object sender, EventArgs e)
    {
        var cityNameToToggle = city_label.Text; // Replace with the city you want to toggle

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

        //OnAppearing, it looks at the city name on the mainpage, and checks for its boolean value.
       //and according to its boolean value, it sets the source of the imagebutton(favButton)
        var cityName = city_label.Text;
        var favCity = CityData.FavCities.FirstOrDefault(c => c.CityName == cityName);

        if (favCity != null)
        {
            favButton.Source = favCity.IsFavorite ? "full_loveheart.svg" : "empty_loveheart.svg";
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

    public async Task GetLocationByCityInFahrenheit(string city)
    {
        this.city = city;
        var result = await WeatherAPIService.GetWeatherInformationInFahrenheit(city);
        WeatherList.Clear();
        foreach (var item in result.list)
        {
            item.ImageSource = item.weather[0].customIcon;
            WeatherList.Add(item);
        }
        CvWeather.ItemsSource = null;
        CvWeather.ItemsSource = WeatherList;

        temp_label.Text = Math.Round(result.list[0].main.temp).ToString() + "°F";
        humid_label.Text = result.list[0].main.humidity.ToString() + "% humid";
        time_label.Text = result.list[0].currentTime.ToString("hh:mm tt");
        time_label2.Text = result.list[0].currentTime.ToString("dddd\n dd MMM yyyy");
        city_label.Text = result.city.name;
        initial_weather_icon.Source = result.list[0].weather[0].customIcon;


    }
    /// <summary>
    /// For refreshview property in xaml file
    /// </summary>
    private async void refreshview_Refreshing(object sender, EventArgs e)
    {
        if (isSwitchToggled)
        {
            // The switch is toggled, use Celsius
            await GetLocationByCity(city_label.Text);
        }
        else
        {
            // The switch is not toggled, use Fahrenheit
            await GetLocationByCityInFahrenheit(city_label.Text);
        }

        refreshview.IsRefreshing = false;
    }
}