namespace SimpleWeather.Views;

public partial class SearchPageView : ContentPage
{
	public SearchPageView()
	{
		InitializeComponent();
	}

    private void gobackButton_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("..");
    }
}