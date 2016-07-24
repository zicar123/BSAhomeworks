using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebAppForecast.Models;

namespace WebAppForecast.Services
{
    public class CitiesServices : ICitiesServices
    {
        private static List<City> _cities;

        public CitiesServices()
        {
            if (_cities == null)
                _cities = new List<City>
                {
                    new City { cityName = "Kiev" },
                    new City { cityName = "Lviv" },
                    new City { cityName = "Kharkiv" },
                    new City { cityName = "Dnipropetrovsk" },
                    new City { cityName = "Odessa" }
                };
        }

        public List<City> GetCities()
        {
            return _cities;
        }

        public async Task<RootObject> DeserializerAsync(string cityName, string dropdownValue)
        {
            var json = "";
            switch (dropdownValue)
            {
                case "For 1 day":
                    using (var wc = new WebClient())
                    {
                        json = await wc.DownloadStringTaskAsync(
                            "http://api.openweathermap.org/data/2.5/forecast?q=" + cityName 
                            + ",&mode=json&cnt=9&units=metric&appid=77b4dd008a7921dfb62679660037f61e");
                    }
                    break;
                case "For 3 days":
                    using (var wc = new WebClient())
                    {
                        json = await wc.DownloadStringTaskAsync(
                            "http://api.openweathermap.org/data/2.5/forecast?q=" + cityName 
                            + ",&mode=json&cnt=25&units=metric&appid=77b4dd008a7921dfb62679660037f61e");
                    }
                    break;
                case "For 5 days":
                    using (var wc = new WebClient())
                    {
                        json = await wc.DownloadStringTaskAsync(
                            "http://api.openweathermap.org/data/2.5/forecast?q=" + cityName 
                            + ",&mode=json&units=metric&appid=77b4dd008a7921dfb62679660037f61e");
                    }
                    break;
            }
            return JsonConvert.DeserializeObject<RootObject>(json);
        }

        public async Task<RootObject> DeserializerAsync(string cityName)
        {
            string json;
            using (var wc = new WebClient())
            {
                 json = await wc.DownloadStringTaskAsync(
                    "http://api.openweathermap.org/data/2.5/forecast?q=" + cityName
                    + ",&mode=json&cnt=9&units=metric&appid=77b4dd008a7921dfb62679660037f61e");
            }
            return JsonConvert.DeserializeObject<RootObject>(json);
        }
    }
}