using System.Collections.Generic;
using WebAppForecast.Models;

namespace WebAppForecast.Services
{
    public interface ICitiesServices
    {
        List<City> GetCities();
        RootObject Deserializer(string cityName, string dropdownValue);
        RootObject Deserializer(string cityName);
    }
}
