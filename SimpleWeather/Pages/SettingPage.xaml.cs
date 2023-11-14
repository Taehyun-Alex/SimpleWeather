namespace SimpleWeather.Pages;

public partial class SettingPage : ContentPage
{
    private MainPage mainPage;


    public SettingPage(MainPage mainPage)
	{
		InitializeComponent();
        this.mainPage = mainPage;
        bool savedValue = Preferences.Get("UnitSwitchValue", true);
        unitSwitch.IsToggled = savedValue;
        Preferences.Set("UnitSwitchValue", savedValue);
    }



    private void xButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }


    private async void unitSwitch_Toggled(object sender, ToggledEventArgs e)
    {
        try
        {
            // Show the loading indicator
            activityIndicator.IsRunning = true;
            activityIndicator.IsVisible = true;
                if (e.Value == false)
                {
                    // The async task
                    await mainPage.GetLocationByCityInFahrenheit(mainPage.city);
                }
                else
                {
                    // The async task
                    await mainPage.GetLocationByCity(mainPage.city);
                }
                Preferences.Set("UnitSwitchValue", e.Value);
            }
        finally
        {
            // Hide the loading indicator
            activityIndicator.IsRunning = false;
            activityIndicator.IsVisible = false;
        }
    }


    private void autoRefreshSwitch_Toggled(object sender, ToggledEventArgs e)
    {

    }

    private void notificationSwitch_Toggled(object sender, ToggledEventArgs e)
    {

    }

    private void darkModeSwitch_Toggled(object sender, ToggledEventArgs e)
    {

    }
}