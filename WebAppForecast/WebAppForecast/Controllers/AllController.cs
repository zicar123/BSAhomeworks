using System.Threading.Tasks;
using System.Web.Mvc;
using WebAppForecast.Models;
using WebAppForecast.Services;

namespace WebAppForecast.Controllers
{
    public class AllController : Controller
    {
        private readonly ICitiesServices _citiesService;
        private readonly IHistoryServices _historyService;
        private static RootObject _deserializedObject;

        public AllController(ICitiesServices services, IHistoryServices hservices)
        {
            _citiesService = services;
            _historyService = hservices;
        }

        [HttpGet]
        public ActionResult AllCities()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AllCities(City model)
        {
            if (ModelState.IsValid)
            {
                _deserializedObject = await _citiesService.DeserializerAsync(model.cityName);
                return RedirectToAction("GetWeatherChoosen");
            }
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> GetWeatherChoosen()
        {
            await _historyService.AddToHistoryAsync(_citiesService, _deserializedObject.city.name);
            return View(_deserializedObject);
        }

        [HttpPost]
        public async Task<ActionResult> GetWeatherChoosen(string cityName, RootObject obj)
        {
            await _historyService.AddToHistoryAsync(_citiesService, cityName, obj.dropdown);
            return View(await _citiesService.DeserializerAsync(cityName, obj.dropdown));
        }

        public ActionResult AddBookmark(string cityName, int cityId)
        {
            return RedirectToAction("AddBookmarkToDb", "MyBookmarks", new {cityName, cityId});
        }
    }
}