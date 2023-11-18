using SimpleWeather.Models;

namespace SimpleWeather.Pages;

public partial class SearchPage : ContentPage
{
    private MainPage mainPage;

    public SearchPage(MainPage mainPage)
    {
        InitializeComponent();
        this.mainPage = mainPage; // Store a reference to the MainPage
        BindingContext = this;
        FilteredCityNames = cityNames;
    }

    private List<string> cityNames = CityData.SortedFavCityNames; // calling the reusable city list from CityData class.


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

    private void FilterCityNames() // provided by ChatGPT
    {
        FilteredCityNames = cityNames
            .Where(city => city.IndexOf(SearchQuery, StringComparison.OrdinalIgnoreCase) >= 0)
            .ToList();
    }

    private void gobackButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

    private async void cityListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item is object selectedCity)
        {
            if (mainPage != null)
            {
                if (Preferences.Get("UnitSwitchValue", true))
                {
                    await mainPage.GetLocationByCity((string)selectedCity);
                    // Navigate back to MainPage
                    await Navigation.PopAsync();
                }
                else
                {
                    await mainPage.GetLocationByCityInFahrenheit((string)selectedCity);
                    // Navigate back to MainPage
                    await Navigation.PopAsync();
                }
            }
        }
    }

    private void xButton_Clicked(object sender, EventArgs e)
    {
        searchBar.Text = "";
    }
}
