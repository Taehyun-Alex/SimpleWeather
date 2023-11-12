namespace SimpleWeather.Pages;

public partial class SettingPage : ContentPage
{
    private MainPage mainPage;

    public SettingPage(MainPage mainPage)
	{
		InitializeComponent();
        this.mainPage = mainPage;
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

            // The async task
            bool isSwitchToggled = e.Value;
            await mainPage.GetLocationByCityInFahrenheit(mainPage.city);
            await Navigation.PopAsync();
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