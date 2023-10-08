namespace SimpleWeather.Views;

public partial class FavouritesPageView : ContentPage
{
	public FavouritesPageView()
	{
		InitializeComponent();
	}

    private void xButton_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("..");
    }
}