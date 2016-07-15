using System.Linq;
using System.Web.Mvc;
using WebAppForecast.Context;

namespace WebAppForecast.Controllers
{
    public class HistoryController : Controller
    {
        public ActionResult GetHistoryList()
        {
            using (var context = new CitiesContext())
            {
                return View(context.history.ToList());
            }
        }

        public ActionResult HistoryForThisCity(int id)
        {
            var context = new CitiesContext();
            return View(context.history.FirstOrDefault(x => x.Id.Equals(id)));

        }
    }
}