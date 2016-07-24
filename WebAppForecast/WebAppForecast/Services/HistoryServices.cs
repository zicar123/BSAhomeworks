using System.Collections.Generic;
using System.Threading.Tasks;
using WebAppForecast.Models;
using WebAppForecast.Context;
using WebAppForecast.ModelsHistory;

namespace WebAppForecast.Services
{
    public class HistoryServices : IHistoryServices
    {
        public async Task AddToHistoryAsync(ICitiesServices citiesService, string name)
        {
            var obj = await citiesService.DeserializerAsync(name);
            using (var context = new CitiesContext())
            {
                var ch = new CityHistory
                {
                    id_city = obj.city.id,
                    CityName = obj.city.name,
                    Histories = new List<History>(obj.list.Count),
                    Added_at = System.DateTime.Now
                };

                for (int i = 0; i < obj.list.Count; i++)
                {
                    ch.Histories.Add(new History
                    {
                        deg = obj.list[i].wind.deg,
                        dt_txt = obj.list[i].dt_txt,
                        humidity = obj.list[i].main.humidity,
                        pressure = obj.list[i].main.pressure,
                        speed = obj.list[i].wind.speed,
                        temp = obj.list[i].main.temp,
                        temp_max = obj.list[i].main.temp_max,
                        temp_min = obj.list[i].main.temp_min
                    });
                }

                context.History.Add(ch);
                await context.SaveChangesAsync();
            }
        }

        public async Task AddToHistoryAsync(ICitiesServices citiesService, string name, string dropDown)
        {
            var obj = await citiesService.DeserializerAsync(name, dropDown);
            using (var context = new CitiesContext())
            {
                var ch = new CityHistory
                {
                    id_city = obj.city.id,
                    CityName = obj.city.name,
                    Histories = new List<History>(obj.list.Count),
                    Added_at = System.DateTime.Now
                };

                for (int i = 0; i < obj.list.Count; i++)
                {
                    ch.Histories.Add(new History
                    {
                        deg = obj.list[i].wind.deg,
                        dt_txt = obj.list[i].dt_txt,
                        humidity = obj.list[i].main.humidity,
                        pressure = obj.list[i].main.pressure,
                        speed = obj.list[i].wind.speed,
                        temp = obj.list[i].main.temp,
                        temp_max = obj.list[i].main.temp_max,
                        temp_min = obj.list[i].main.temp_min
                    });
                }

                context.History.Add(ch);
                await context.SaveChangesAsync();
            }
        }
    }
}