namespace SimpleWeather.Pages;

public partial class SettingPage : ContentPage
{
	public SettingPage()
	{
		InitializeComponent();
	}

    private void xButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}