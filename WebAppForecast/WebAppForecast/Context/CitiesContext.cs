using System.Data.Entity;
using WebAppForecast.ModelsHistory;

namespace WebAppForecast.Context
{
    public class CitiesContext : DbContext
    {
        public DbSet<CityHistory> history { get; set; }

        public CitiesContext() : base()
        {
            Database.SetInitializer<CitiesContext>(new CitiesContextInitializer());
        }

        public System.Data.Entity.DbSet<WebAppForecast.ModelsHistory.History> Histories { get; set; }
    }
}