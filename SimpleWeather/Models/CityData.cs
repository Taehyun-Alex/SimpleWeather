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
        public static List<string> CityNames { get; } = new List<string>
        {
        "London",
        "Perth",
        "Seoul",
        "Tokyo",
        "Rio de Janeiro",
        "Toronto",
        "Santiago",
        "Shanghai",
        "Cairo",
        "Delhi",
        "Paris",
        "Jakarta",
        "Tehran",
        "Osaka",
        "Kuala Lumpur",
        "Lagos",
        "Manila",
        "Madrid",
        "Bangkok",
        "New York"
        };

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

        public static List<FavCityItem> FavCities { get; } = new List<FavCityItem>
        {
            new FavCityItem { CityName = "London", ImageSource = "empty_loveheart.png", IsFavorite = false },
            new FavCityItem { CityName = "Perth", ImageSource = "empty_loveheart.png", IsFavorite = false },
            new FavCityItem { CityName = "Seoul", ImageSource = "empty_loveheart.png", IsFavorite = false },
            new FavCityItem { CityName = "Tokyo", ImageSource = "empty_loveheart.png", IsFavorite = false }
        };
    }
}
