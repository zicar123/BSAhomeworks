
namespace WebAppForecast.Services
{
    public interface IHistoryServices
    {
        void AddToHistory(ICitiesServices citiesService, string name);
        void AddToHistory(ICitiesServices citiesService, string name, string dropDown);
    }
}
