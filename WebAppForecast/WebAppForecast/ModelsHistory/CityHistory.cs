using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAppForecast.ModelsHistory
{
    public class CityHistory
    {
        public CityHistory()
        {
            Histories = new List<History>();
        }

        [Key, Required]
        public int Id { get; set; }

        public string CityName { get; set; }
        public int id_city { get; set; }
        public DateTime Added_at { get; set; }

        public virtual List<History> Histories { get; set; }
    }
}