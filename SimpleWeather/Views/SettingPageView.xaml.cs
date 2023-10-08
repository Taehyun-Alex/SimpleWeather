namespace SimpleWeather.Views;

public partial class SettingPageView : ContentPage
{
	public SettingPageView()
	{
		InitializeComponent();
	}

    private void xButton_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("..");
    }
}