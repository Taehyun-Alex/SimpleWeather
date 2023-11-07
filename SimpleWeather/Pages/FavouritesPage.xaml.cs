namespace SimpleWeather.Pages;

public partial class FavouritesPage : ContentPage
{
	public FavouritesPage()
	{
		InitializeComponent();
	}

    private void xButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}