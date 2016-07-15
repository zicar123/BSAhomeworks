using System.Web.Mvc;
using WebAppForecast.Services;
using WebAppForecast.Models;

namespace WebAppForecast.Controllers
{
    public class CityController : Controller
    {
        private ICitiesServices citiesService;
        private IHistoryServices historyService;

        public CityController(ICitiesServices services, IHistoryServices hservices)
        {
            citiesService = services;
            historyService = hservices;
        }

        public ActionResult Cities()
        {
            return View(citiesService.GetCities());
        }

        public ActionResult GetWeatherForThisCity(string name)
        {
            historyService.AddToHistory(citiesService, name);
            return View(citiesService.Deserializer(name));
        }

        [HttpPost]
        public ActionResult GetWeatherForThisCity(string cityName, RootObject obj)
        {
            historyService.AddToHistory(citiesService, cityName, obj.dropdown);
            return View(citiesService.Deserializer(cityName, obj.dropdown));
        }
    }
}
