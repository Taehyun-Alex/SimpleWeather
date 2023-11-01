namespace SimpleWeather;

public partial class App : Application
{
    public static string ApiUrl { get; set; } // tried this for updating mainpage when an item in searchpage is clicked.
    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}

}
