namespace SimpleWeather.Pages;

public partial class SearchPage : ContentPage
{
	public SearchPage()
	{
		InitializeComponent();
	}

    private void gobackButton_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("..");
    }
}