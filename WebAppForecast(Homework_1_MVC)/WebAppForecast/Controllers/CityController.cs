using System.Web.Mvc;
using WebAppForecast.Services;

using WebAppForecast.Models;

namespace WebAppForecast.Controllers
{
    public class CityController : Controller
    {
        private ICitiesServices citiesService;

        public CityController(ICitiesServices services)
        {
            citiesService = services;
        }

        public ActionResult Cities()
        {
            return View(citiesService.GetCities());
        }

        public ActionResult GetWeatherForThisCity(string name)
        {
            return View(citiesService.Deserializer(name));
        }

        [HttpPost]
        public ActionResult GetWeatherForThisCity(string cityName, RootObject obj)
        { 
            return View(citiesService.Deserializer(cityName, obj.dropdown));
        }
    }
}
