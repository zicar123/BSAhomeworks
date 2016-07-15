using System.Web.Mvc;
using WebAppForecast.Models;
using WebAppForecast.Services;

namespace WebAppForecast.Controllers
{
    public class AllController : Controller
    {
        private ICitiesServices citiesService;
        private IHistoryServices historyService;
        private static RootObject deserializedObject;

        public AllController(ICitiesServices services, IHistoryServices hservices)
        {
            citiesService = services;
            historyService = hservices;
        }

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
            historyService.AddToHistory(citiesService, deserializedObject.city.name);
            return View(deserializedObject);
        }

        [HttpPost]
        public ActionResult GetWeatherChoosen(string cityName, RootObject obj)
        {
            historyService.AddToHistory(citiesService, cityName, obj.dropdown);
            return View(citiesService.Deserializer(cityName, obj.dropdown));
        }

        public ActionResult AddBookmark(string cityName, int cityId)
        {
            return RedirectToAction("AddBookmarkToDB", "MyBookmarks", new { cityName = cityName, cityId = cityId});
        }
    }
}