using SimpleWeather.Models.ApiModels;

namespace SimpleWeather.Pages;

public partial class SettingPage : ContentPage
{
    private MainPage mainPage;


    public SettingPage(MainPage mainPage)
	{
		InitializeComponent();
        this.mainPage = mainPage;

        // for unit swtich
        bool savedValue = Preferences.Get("UnitSwitchValue", true);
        unitSwitch.IsToggled = savedValue;
        Preferences.Set("UnitSwitchValue", savedValue);

        // for autoRefresh switch
        bool autoRefreshValue = Preferences.Get("AutoRefreshSwitchValue", true);
        autoRefreshSwitch.IsToggled = autoRefreshValue;
        Preferences.Set("AutoRefreshSwitchValue", autoRefreshValue);

        // for notification switch
        bool notificationValue = Preferences.Get("NotificationSwitchValue", true);
        notificationSwitch.IsToggled = notificationValue;
        Preferences.Set("NotificationSwitchValue", notificationValue);

        // for darkmode switch
        bool darkModeValue = Preferences.Get("DarkModeValue", false);
        darkModeSwitch.IsToggled = darkModeValue;
        Preferences.Set("DarkModeValue", darkModeValue);
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
        mainPage.HandleAutoRefresh(e.Value);
        Preferences.Set("AutoRefreshSwitchValue", e.Value);
    }

    private void notificationSwitch_Toggled(object sender, ToggledEventArgs e)
    {
        Preferences.Set("NotificationSwitchValue", e.Value);
    }

    private void darkModeSwitch_Toggled(object sender, ToggledEventArgs e)
    {
        Application.Current.Resources.MergedDictionaries.Clear();

        if (e.Value) // from Aaron's week19 recording
        {
            Application.Current.Resources.MergedDictionaries.Add(new DarkTheme());
        }
        else
        {
            Application.Current.Resources.MergedDictionaries.Add(new LightTheme());
        }
        Preferences.Set("DarkModeValue", e.Value);

    }

    private void ImageButton_Clicked(object sender, EventArgs e) // provided by ChatGPT
    {
        // Get the text from the Entry
        string entryText = FeedbackEntry.Text;

        if (!string.IsNullOrEmpty(entryText))
        {
            // Get the writable directory
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            // Combine the directory with the file name
            string filePath = Path.Combine(folderPath, "Feedback.txt");

            try
            {
                // Check if the file exists
                if (!File.Exists(filePath))
                {
                    // Create the file if it doesn't exist
                    File.WriteAllText(filePath, entryText);
                }
                else
                {
                    // Append the text to the existing file
                    File.AppendAllText(filePath, Environment.NewLine + entryText);
                }

                // Clear the entry
                FeedbackEntry.Text = "";

                // Display a message
                DisplayAlert("Success", "Thank you\nYour feedback has been saved.", "OK");
            }
            catch (Exception ex)
            {
                // Handle exceptions, e.g., display an error message
                DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }
        else
        {
            // Display an alert if the entry is empty
            DisplayAlert("Error", "Please enter some text.", "OK");
        }
    }
}