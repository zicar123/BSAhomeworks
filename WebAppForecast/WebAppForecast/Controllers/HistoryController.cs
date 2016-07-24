using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebAppForecast.Context;

namespace WebAppForecast.Controllers
{
    public class HistoryController : Controller
    {
        public async Task<ActionResult> GetHistoryList()
        {
            using (var context = new CitiesContext())
            {
                return View(await context.History.ToListAsync());
            }
        }

        public async Task<ActionResult> HistoryForThisCity(int id)
        {
            var context = new CitiesContext();
            return View(await context.History.FirstOrDefaultAsync(x => x.Id.Equals(id)));

        }
    }
}