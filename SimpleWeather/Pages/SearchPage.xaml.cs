namespace SimpleWeather.Pages;

public partial class SearchPage : ContentPage
{
	private List<string> cityNames = new List<string> // typed in the list of cities manually for now. Try to connect it to the API city list.
	{
		"London",
		"Perth",
		"Seoul",
		"Tokyo",
		"Rio de Janeiro",
		"Toronto",
		"Santiago", 
		"Shanghai",
		"Cairo",
		"Delhi",
		"Paris",
		"Jakarta",
		"Tehran",
		"Osaka",
		"Kuala Lumpur",
		"Lagos",
		"Manila",
		"Madrid",
		"Bangkok",
		"New York"
	};

	private string searchQuery;
	public string SearchQuery
	{
		get { return searchQuery;}
		set
		{
			if (searchQuery != value)
			{
				searchQuery = value;
				FilterCityNames();
			}
		}
	}

	private List<string> filteredCityNames;
	public List<string> FilteredCityNames
	{
		get { return filteredCityNames;}
		set
		{
			if (filteredCityNames != value)
			{
				filteredCityNames = value;
				cityListView.ItemsSource = filteredCityNames;
			}
		}
	}
	public SearchPage() //constructor for searchpage
	{
		InitializeComponent();
        BindingContext = this; // Set the ViewModel as the binding context. Without this, the search will not work properly.
        FilteredCityNames = cityNames;
	}

    private void FilterCityNames() // got it from chatgpt, try to understand it.
    {
        FilteredCityNames = cityNames
            .Where(city => city.IndexOf(SearchQuery, StringComparison.OrdinalIgnoreCase) >= 0)
            .ToList();
    }

    private void gobackButton_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("..");
    }

    private async void cityListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item is string selectedCity)
        {
            // Update the API address with the selected city name
            App.ApiUrl = $"https://pro.openweathermap.org/data/2.5/forecast/hourly?q={selectedCity}&appid=59a4ade3192313d407110c1eb429f1a8&units=metric&cnt=10";

            await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
        }
    }
}