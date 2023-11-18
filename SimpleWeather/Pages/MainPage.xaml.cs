using Microsoft.Maui.Controls.PlatformConfiguration;
using SimpleWeather.Models;
using System.Timers;


namespace SimpleWeather.Pages;

public partial class MainPage : ContentPage
{
    public List<Models.ApiModels.List> WeatherList;
    public string city;
    private bool isCitySet = false; //set this boolean to see if the city has been set.
    private readonly System.Timers.Timer timer; 
    private bool isAutoRefreshEnabled;
    private bool isNotificationEnabled;
    private bool isDarkModeEnabled;
    

    [Obsolete]
    public MainPage()
	{
		InitializeComponent();
        WeatherList = new List<Models.ApiModels.List>();

        // For auto refresh switch
        timer = new System.Timers.Timer(60000); // set up the timer for 60seconds(60000 milliseconds) for autoreloading the mainpage.
        timer.Elapsed += TimerElapsed;
        isAutoRefreshEnabled = Preferences.Get("AutoRefreshSwitchValue", true); //bring the switch value from settingpage.
        isDarkModeEnabled = Preferences.Get("DarkModeValue", true); // does this do anything?
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

    }

    private void searchButton_Clicked(object sender, EventArgs e)
    {
        SearchPage searchPage = new SearchPage(this);
        Navigation.PushAsync(searchPage);
    }

    [Obsolete]
    protected async override void OnAppearing()
    {
        base.OnAppearing();

        isNotificationEnabled = Preferences.Get("NotificationSwitchValue", true);

        if (!isCitySet) // if the city has not set yet, the default will be Perth.
        {
            await GetLocationByCity("Perth");
            isCitySet = true; // Mark the city as set
        }

        //OnAppearing, it looks at the city name on the mainpage, and checks for its boolean value.
        //and according to its boolean value, it sets the source of the imagebutton(favButton)
        var favCity = CityData.FavCities.FirstOrDefault(c => c.CityName == city);

        if (favCity != null)
        {
            favButton.Source = favCity.IsFavorite ? "full_loveheart.svg" : "empty_loveheart.svg";
        }

        if (isAutoRefreshEnabled)
        {
            timer.Start();
        }

        else
        {
            timer.Stop();
        }

        if (isNotificationEnabled)
        {
            ShowNotification("Hello user! \nHave a beautiful day");
        }
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        timer.Stop(); // so when we go to different page, timer stops.
    }

    public async Task GetLocationByCity(string city)
    {
        this.city = city;
        var result = await WeatherAPIService.GetWeatherInformation(city);
        WeatherList.Clear();
        foreach (var item in result.list)
        {
            item.ImageSource = item.weather[0].customIcon;
            item.UnitType = "°C";
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
            item.UnitType = "°F";
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
    /// reusable async method
    /// </summary>
    private async Task RefreshWeatherData()
    {
        bool unitSwitchValue = Preferences.Get("UnitSwitchValue", true);
        if (unitSwitchValue) // fix this
        {
            // The switch is toggled, use Celsius
            await GetLocationByCity(city);
        }
        else
        {
            // The switch is not toggled, use Fahrenheit
            await GetLocationByCityInFahrenheit(city);
        }

        refreshview.IsRefreshing = false;
    }

    /// <summary>
    /// For refreshview property in xaml file
    /// </summary>
    private async void refreshview_Refreshing(object sender, EventArgs e)
    {
        await RefreshWeatherData();
    }

    /// <summary>
    /// if the timer reaches the time, it performs the action.
    /// </summary>
    [Obsolete]
    private void TimerElapsed(object sender, ElapsedEventArgs e) 
    {

        Device.BeginInvokeOnMainThread(async () =>
        {
            // Trigger the data refresh
            await RefreshWeatherData();
        });
    }

    /// <summary>
    /// using the switch value from the setting page, it determines whether to refresh.
    /// </summary>
    /// <param name="isAutoRefreshEnabled"></param>
    public void HandleAutoRefresh(bool isAutoRefreshEnabled)
    {
        this.isAutoRefreshEnabled = isAutoRefreshEnabled;

        if (isAutoRefreshEnabled)
        {
            StartAutoRefresh();
        }
        else
        {
            StopAutoRefresh();
        }
    }

    private void StartAutoRefresh()
    {
        timer.Start();
    }

    private void StopAutoRefresh()
    {
        timer.Stop();
    }

    [Obsolete]
    private void ShowNotification(string message)
    {
        if (Device.RuntimePlatform == Device.Android)
        {
            DisplayAlert("Notification", message, "Thank you");
        }
    }

    private void OnFavouritesSwipe(object sender, EventArgs e)
    {
        // Perform navigation to the FavouritesPage
        FavouritesPage favPage = new FavouritesPage();
        Navigation.PushAsync(favPage);
    }
}