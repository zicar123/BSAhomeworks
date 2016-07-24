using System.Threading.Tasks;

namespace WebAppForecast.Services
{
    public interface IHistoryServices
    {
        Task AddToHistoryAsync(ICitiesServices citiesService, string name);
        Task AddToHistoryAsync(ICitiesServices citiesService, string name, string dropDown);
    }
}
