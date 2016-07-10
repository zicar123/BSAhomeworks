using System.Web.Mvc;
using WebAppForecast.Models;
using WebAppForecast.Services;

namespace WebAppForecast.Controllers
{
    public class AllController : Controller
    {
        private ICitiesServices citiesService;

        public AllController(ICitiesServices services)
        {
            citiesService = services;
        }

        private static RootObject deserializedObject;

        public ActionResult AllCities()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AllCities(City model)
        {
            if (ModelState.IsValid)
            {
                deserializedObject = citiesService.Deserializer(model.cityName);
                return RedirectToAction("GetWeatherChoosen");
            }
            return View();
        }

        public ActionResult GetWeatherChoosen()
        {
            return View(deserializedObject);
        }

        [HttpPost]
        public ActionResult GetWeatherChoosen(string cityName, RootObject obj)
        {
            return View(citiesService.Deserializer(cityName, obj.dropdown));
        }
    }
}