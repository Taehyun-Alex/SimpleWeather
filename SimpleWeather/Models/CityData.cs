using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SimpleWeather.Models
{
    public static class CityData
    {
        public class FavCityItem :INotifyPropertyChanged //create a class with properties so we can bind it to xaml colletionview.
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

            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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

        };

        public static List<string> FavCityNames => FavCities.Select(favCity => favCity.CityName).ToList(); //using the list above, extract a list of city names.
    }
}
