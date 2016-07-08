using System.Web.Mvc;
using WebAppForecast.Models;
using WebAppForecast.Services;

namespace WebAppForecast.Controllers
{
    public class AllController : Controller
    {
        private static RootObject deserializedObject;

        public ActionResult AllCities()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AllCities(UserCity model)
        {
            if (ModelState.IsValid)
            {
                deserializedObject = new CitiesServices().Deserializer(model.userCity);
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
            return View(new CitiesServices().Deserializer(cityName, obj.dropdown));
        }
    }
}