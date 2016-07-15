using System.Collections.Generic;
using WebAppForecast.Models;
using WebAppForecast.Context;
using WebAppForecast.ModelsHistory;

namespace WebAppForecast.Services
{
    public class HistoryServices : IHistoryServices
    {
        public void AddToHistory(ICitiesServices citiesService, string name)
        {
            RootObject obj = citiesService.Deserializer(name);
            using (CitiesContext context = new CitiesContext())
            {
                CityHistory ch = new CityHistory()
                {
                    id_city = obj.city.id,
                    CityName = obj.city.name,
                    Histories = new List<History>(obj.list.Count),
                    Added_at = System.DateTime.Now
                };

                for (int i = 0; i < obj.list.Count; i++)
                {
                    ch.Histories.Add(new History()
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

                context.history.Add(ch);
                context.SaveChanges();
            }
        }

        public void AddToHistory(ICitiesServices citiesService, string name, string dropDown)
        {
            RootObject obj = citiesService.Deserializer(name, dropDown);
            using (CitiesContext context = new CitiesContext())
            {
                CityHistory ch = new CityHistory()
                {
                    id_city = obj.city.id,
                    CityName = obj.city.name,
                    Histories = new List<History>(obj.list.Count),
                    Added_at = System.DateTime.Now
                };

                for (int i = 0; i < obj.list.Count; i++)
                {
                    ch.Histories.Add(new History()
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

                context.history.Add(ch);
                context.SaveChanges();
            }
        }
    }
}