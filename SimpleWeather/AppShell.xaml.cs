using SimpleWeather.Views;

namespace SimpleWeather;


public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(MainPageView), typeof(MainPageView));
        Routing.RegisterRoute(nameof(SearchPageView), typeof(SearchPageView));
        Routing.RegisterRoute(nameof(FavouritesPageView), typeof(FavouritesPageView));
        Routing.RegisterRoute(nameof(SettingPageView), typeof(SettingPageView));

    }
}
