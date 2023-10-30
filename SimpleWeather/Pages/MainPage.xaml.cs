namespace SimpleWeather.Pages;

public partial class MainPage : ContentPage
{
    public List<Models.ApiModels.List> WeatherList;
	public MainPage()
	{
		InitializeComponent();
        WeatherList = new List<Models.ApiModels.List>();
	}

    private void menuButton_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync(nameof(SettingPage));
    }

    
    private void favButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(FavouritesPage));
    }

    private void searchButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(SearchPage));
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        var result = await WeatherAPIService.GetWeatherInformation();
        foreach (var item in result.list)
        {
            item.ImageSource = item.weather[0].customIcon;
            WeatherList.Add(item);
        }
        CvWeather.ItemsSource = WeatherList;

        temp_label.Text = Math.Round(result.list[0].main.temp).ToString() + "°C";
        humid_label.Text = result.list[0].main.humidity.ToString() + "% humid";
        time_label.Text = result.list[0].currentTime.ToString("hh:mm tt");
        time_label2.Text = result.list[0].currentTime.ToString("dddd\n dd MMM yyyy");
        city_label.Text = result.city.name;
        initial_weather_icon.Source = result.list[0].weather[0].customIcon;
    }

    
}