namespace SimpleWeather;

public partial class App : Application
{
    public static string ApiUrl { get; set; }
    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}

}
