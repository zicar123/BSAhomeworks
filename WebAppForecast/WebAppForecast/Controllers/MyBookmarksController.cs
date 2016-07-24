using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebAppForecast.Context;
using WebAppForecast.Entity;

namespace WebAppForecast.Controllers
{
    public class MyBookmarksController : Controller
    {
        public async Task<ActionResult> Bookmarks()
        {
            using (var context = new BookmarksContext())
            {
                return View(await context.Bookmarks.ToListAsync());
            }
        }

        public async Task<ActionResult> DeleteBookmark(int bmId)
        {
            using (var context = new BookmarksContext())
            {
                context.Bookmarks.Remove(await context.Bookmarks.FirstOrDefaultAsync(x => x.BookmarkId.Equals(bmId)));
                await context.SaveChangesAsync();
                return RedirectToAction("Bookmarks");
            }
        }

        public async Task<ActionResult> GetWeather(int cityId)
        {
            using (var context = new BookmarksContext())
            {
                return RedirectToAction("GetWeatherForThisCity", "City", new
                {
                    Name = (await context.Bookmarks.FirstOrDefaultAsync(x => x.BookmarkId.Equals(cityId))).Title
                });
            }
        }

        public async Task<ActionResult> AddBookmarkToDb(string cityName, int cityId)
        {
            using (var context = new BookmarksContext())
            {
                try
                {
                    context.Bookmarks.Add(new Bookmark { BookmarkId = cityId, Title = cityName });
                    await context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return RedirectToAction("GetWeatherChoosen", "All");
                }
                return RedirectToAction("GetWeatherForThisCity", "City", new { Name = cityName });
            }
        }
    }
}