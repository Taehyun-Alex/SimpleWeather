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
	

    private void FilterCityNames() // got it from chatgpt, try to understand it.
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
                await mainPage.GetLocationByCity((string)selectedCity);
                // Navigate back to MainPage
                await Navigation.PopAsync();
            }
        }
    }
}