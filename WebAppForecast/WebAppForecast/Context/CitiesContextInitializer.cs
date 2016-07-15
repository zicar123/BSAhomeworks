using System.Data.Entity;

namespace WebAppForecast.Context
{
    public class CitiesContextInitializer : DropCreateDatabaseIfModelChanges<CitiesContext>
    {
    }
}