using System.Data.Entity;
using WebAppForecast.Entity;

namespace WebAppForecast.Context
{
    public class BookmarksContextInitializer : DropCreateDatabaseIfModelChanges<BookmarksContext>
    {
        protected override void Seed(BookmarksContext context)
        {
            context.Bookmarks.Add(new Bookmark() { Title = "Moscow", BookmarkId = 524901 });
            context.Bookmarks.Add(new Bookmark() { Title = "Melbourne", BookmarkId = 2158177 });
            context.Bookmarks.Add(new Bookmark() { Title = "London", BookmarkId = 2643743 });
            context.Bookmarks.Add(new Bookmark() { Title = "Lisbon", BookmarkId = 6458923 });
        }
    }
}