using SimpleWeather.Pages;

namespace SimpleWeather;


public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        Routing.RegisterRoute(nameof(SearchPage), typeof(SearchPage));
        Routing.RegisterRoute(nameof(FavouritesPage), typeof(FavouritesPage));
        Routing.RegisterRoute(nameof(SettingPage), typeof(SettingPage));

    }
}
