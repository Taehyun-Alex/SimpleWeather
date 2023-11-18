using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SimpleWeather.Models.ApiModels;

namespace SimpleWeather.Models
{
    public static class CityData
    {
        public class FavCityItem :INotifyPropertyChanged // create a class with properties so we can bind it to xaml colletionview.
        {
            private string cityName;
            private string imageSource;
            private bool isFavorite;

            public string CityName
            {
                get { return cityName; }
                set
                {
                    if (cityName != value)
                    {
                        cityName = value;
                        OnPropertyChanged();
                    }
                }
            }

            public string ImageSource
            {
                get { return imageSource; }
                set
                {
                    if (imageSource != value)
                    {
                        imageSource = value;
                        OnPropertyChanged();
                    }
                }
            }

            public bool IsFavorite
            {
                get { return isFavorite; }
                set
                {
                    if (isFavorite != value)
                    {
                        isFavorite = value;
                        OnPropertyChanged();
                    }
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) // provided by ChatGPT
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

            /// <summary>
            /// Saves the properties(image source, bool value of isFavourite) of a city.
            /// </summary>
            public void SaveToPreferences()
            {
                Preferences.Set($"{CityName}_ImageSource", ImageSource);
                Preferences.Set($"{CityName}_IsFavorite", IsFavorite);
            }

            /// <summary>
            /// Loads the properties(image source, bool value of isFavourite) of a city.
            /// </summary>
            public void LoadFromPreferences()
            {
                ImageSource = Preferences.Get($"{CityName}_ImageSource", "default_image.png");
                IsFavorite = Preferences.Get($"{CityName}_IsFavorite", false);
            }
        }

        public static List<FavCityItem> FavCities { get; } = new List<FavCityItem> //manual list of cities with boolean value
        {
            new FavCityItem { CityName = "London", ImageSource = "empty_loveheart.png", IsFavorite = false },
            new FavCityItem { CityName = "Perth", ImageSource = "empty_loveheart.png", IsFavorite = false },
            new FavCityItem { CityName = "Seoul", ImageSource = "empty_loveheart.png", IsFavorite = false },
            new FavCityItem { CityName = "Tokyo", ImageSource = "empty_loveheart.png", IsFavorite = false },
            new FavCityItem { CityName = "Rio de Janeiro", ImageSource = "empty_loveheart.png", IsFavorite = false },
            new FavCityItem { CityName = "Toronto", ImageSource = "empty_loveheart.png", IsFavorite = false },
            new FavCityItem { CityName = "Santiago", ImageSource = "empty_loveheart.png", IsFavorite = false },
            new FavCityItem { CityName = "Cairo", ImageSource = "empty_loveheart.png", IsFavorite = false },
            new FavCityItem { CityName = "Delhi", ImageSource = "empty_loveheart.png", IsFavorite = false },
            new FavCityItem { CityName = "Paris", ImageSource = "empty_loveheart.png", IsFavorite = false },
            new FavCityItem { CityName = "Jakarta", ImageSource = "empty_loveheart.png", IsFavorite = false },
            new FavCityItem { CityName = "Tehran", ImageSource = "empty_loveheart.png", IsFavorite = false },
            new FavCityItem { CityName = "Osaka", ImageSource = "empty_loveheart.png", IsFavorite = false },
            new FavCityItem { CityName = "Kuala Lumpur", ImageSource = "empty_loveheart.png", IsFavorite = false },
            new FavCityItem { CityName = "Lagos", ImageSource = "empty_loveheart.png", IsFavorite = false },
            new FavCityItem { CityName = "Manila", ImageSource = "empty_loveheart.png", IsFavorite = false },
            new FavCityItem { CityName = "Madrid", ImageSource = "empty_loveheart.png", IsFavorite = false },
            new FavCityItem { CityName = "Bangkok", ImageSource = "empty_loveheart.png", IsFavorite = false },
            new FavCityItem { CityName = "Makassar", ImageSource = "empty_loveheart.png", IsFavorite = false },
            new FavCityItem { CityName = "Incheon", ImageSource = "empty_loveheart.png", IsFavorite = false },
            new FavCityItem { CityName = "Beijing", ImageSource = "empty_loveheart.png", IsFavorite = false },
            new FavCityItem { CityName = "Budapest", ImageSource = "empty_loveheart.png", IsFavorite = false },
            new FavCityItem { CityName = "Canberra", ImageSource = "empty_loveheart.png", IsFavorite = false },
            new FavCityItem { CityName = "Adelaide", ImageSource = "empty_loveheart.png", IsFavorite = false },
            new FavCityItem { CityName = "Darwin", ImageSource = "empty_loveheart.png", IsFavorite = false },
            new FavCityItem { CityName = "Melbourne", ImageSource = "empty_loveheart.png", IsFavorite = false },
            new FavCityItem { CityName = "Sydney", ImageSource = "empty_loveheart.png", IsFavorite = false },
            new FavCityItem { CityName = "Chicago", ImageSource = "empty_loveheart.png", IsFavorite = false },
            new FavCityItem { CityName = "Dublin", ImageSource = "empty_loveheart.png", IsFavorite = false },
            new FavCityItem { CityName = "Ha Noi", ImageSource = "empty_loveheart.png", IsFavorite = false },
            new FavCityItem { CityName = "Havana", ImageSource = "empty_loveheart.png", IsFavorite = false },
            new FavCityItem { CityName = "Helsinki", ImageSource = "empty_loveheart.png", IsFavorite = false },
            new FavCityItem { CityName = "Hong Kong", ImageSource = "empty_loveheart.png", IsFavorite = false },
            new FavCityItem { CityName = "Istanbul", ImageSource = "empty_loveheart.png", IsFavorite = false },
            new FavCityItem { CityName = "Honolulu", ImageSource = "empty_loveheart.png", IsFavorite = false },
            new FavCityItem { CityName = "Jerusalem", ImageSource = "empty_loveheart.png", IsFavorite = false },
            new FavCityItem { CityName = "Kathmandu", ImageSource = "empty_loveheart.png", IsFavorite = false },
            new FavCityItem { CityName = "Lisbon", ImageSource = "empty_loveheart.png", IsFavorite = false },
            new FavCityItem { CityName = "Los Angeles", ImageSource = "empty_loveheart.png", IsFavorite = false },
            new FavCityItem { CityName = "Luxembourg", ImageSource = "empty_loveheart.png", IsFavorite = false },
            new FavCityItem { CityName = "Madrid", ImageSource = "empty_loveheart.png", IsFavorite = false },
            new FavCityItem { CityName = "Manila", ImageSource = "empty_loveheart.png", IsFavorite = false },
            new FavCityItem { CityName = "Mexico City", ImageSource = "empty_loveheart.png", IsFavorite = false },
            new FavCityItem { CityName = "Milan", ImageSource = "empty_loveheart.png", IsFavorite = false },
            new FavCityItem { CityName = "Montreal", ImageSource = "empty_loveheart.png", IsFavorite = false },
            new FavCityItem { CityName = "Moscow", ImageSource = "empty_loveheart.png", IsFavorite = false },
            new FavCityItem { CityName = "Mumbai", ImageSource = "empty_loveheart.png", IsFavorite = false },
            new FavCityItem { CityName = "Munich", ImageSource = "empty_loveheart.png", IsFavorite = false },
            new FavCityItem { CityName = "Nazareth", ImageSource = "empty_loveheart.png", IsFavorite = false },
            new FavCityItem { CityName = "Ottawa", ImageSource = "empty_loveheart.png", IsFavorite = false }

        };

        public static List<string> FavCityNames => FavCities.Select(favCity => favCity.CityName).ToList(); //using the list above, extract a list of city names.
        public static List<string> SortedFavCityNames => FavCityNames.OrderBy(city => city).ToList(); // sort the list above.
    }
}
