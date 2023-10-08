namespace SimpleWeather;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

	}

	public class SlidePageTransition
	{

	}

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {

		if (true)
		{
            await Shell.Current.GoToAsync("//SettingPage", true);
		}
    }
}

