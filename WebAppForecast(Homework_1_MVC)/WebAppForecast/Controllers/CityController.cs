using System.Web.Mvc;
using WebAppForecast.Services;

using WebAppForecast.Models;

namespace WebAppForecast.Controllers
{
    public class CityController : Controller
    {
        private CitiesServices citiesService;

        public CityController()
        {
            citiesService = new CitiesServices();
        }

        public ActionResult Cities()
        {
            return View(citiesService.GetCities());
        }

        public ActionResult GetWeatherForThisCity(string name)
        {
            return View(new CitiesServices().Deserializer(name));
        }

        [HttpPost]
        public ActionResult GetWeatherForThisCity(string cityName, RootObject obj)
        { 
            return View(new CitiesServices().Deserializer(cityName, obj.dropdown));
        }
    }
}
