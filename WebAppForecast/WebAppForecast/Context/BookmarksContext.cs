using System.Data.Entity;
using WebAppForecast.Entity;

namespace WebAppForecast.Context
{
    public class BookmarksContext : DbContext
    {
        public DbSet<Bookmark> Bookmarks { get; set; }

        public BookmarksContext() : base()
        {
            Database.SetInitializer<BookmarksContext>(new BookmarksContextInitializer());
        }
    }
}