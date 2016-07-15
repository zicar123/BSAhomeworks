using System;
using System.Linq;
using System.Web.Mvc;
using WebAppForecast.Context;
using WebAppForecast.Entity;

namespace WebAppForecast.Controllers
{
    public class MyBookmarksController : Controller
    {
        public ActionResult Bookmarks()
        {
            using (var context = new BookmarksContext())
            {
                return View(context.Bookmarks.ToList<Bookmark>());
            }
        }


        public ActionResult DeleteBookmark(int bmId)
        {
            using (var context = new BookmarksContext())
            {
                context.Bookmarks.Remove(context.Bookmarks.FirstOrDefault(x => x.BookmarkId.Equals(bmId)));
                context.SaveChanges();
                return RedirectToAction("Bookmarks");
            }
        }

        public ActionResult GetWeather(int cityId)
        {
            using (var context = new BookmarksContext())
            {
                return RedirectToAction("GetWeatherForThisCity", "City", new
                {
                    Name = context.Bookmarks.FirstOrDefault(x => x.BookmarkId.Equals(cityId)).Title
                });
            }
        }

        public ActionResult AddBookmarkToDB(string cityName, int cityId)
        {
            using (var context = new BookmarksContext())
            {
                try
                {
                    context.Bookmarks.Add(new Bookmark() { BookmarkId = cityId, Title = cityName });
                    context.SaveChanges();
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