using System.Collections.Generic;
using System.Threading.Tasks;
using WebAppForecast.Models;

namespace WebAppForecast.Services
{
    public interface ICitiesServices
    {
        List<City> GetCities();
        Task<RootObject> DeserializerAsync(string cityName, string dropdownValue);
        Task<RootObject> DeserializerAsync(string cityName);
    }
}
