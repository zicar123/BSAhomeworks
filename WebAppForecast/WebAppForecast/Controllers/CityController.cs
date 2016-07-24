using System.Threading.Tasks;
using System.Web.Mvc;
using WebAppForecast.Services;
using WebAppForecast.Models;

namespace WebAppForecast.Controllers
{
    public class CityController : Controller
    {
        private readonly ICitiesServices _citiesService;
        private readonly IHistoryServices _historyService;

        public CityController(ICitiesServices services, IHistoryServices hservices)
        {
            _citiesService = services;
            _historyService = hservices;
        }

        public ActionResult Cities()
        {
            return View(_citiesService.GetCities());
        }

        [HttpGet]
        public async Task<ActionResult> GetWeatherForThisCity(string name)
        {
            await _historyService.AddToHistoryAsync(_citiesService, name);
            return View(await _citiesService.DeserializerAsync(name));
        }

        [HttpPost]
        public async Task<ActionResult> GetWeatherForThisCity(string cityName, RootObject obj)
        {
            await _historyService.AddToHistoryAsync(_citiesService, cityName, obj.dropdown);
            return View(await _citiesService.DeserializerAsync(cityName, obj.dropdown));
        }
    }
}
