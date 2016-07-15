
namespace WebAppForecast.ModelsHistory
{
    public class History
    {
        public int HistoryId { get; set; }

        public string dt_txt { get; set; }
        public double temp { get; set; }
        public double pressure { get; set; }
        public int humidity { get; set; }
        public double speed { get; set; }
        public double deg { get; set; }
        public double temp_max { get; set; }
        public double temp_min { get; set; }

        //[ForeignKey("CityHistoryRefId")]
        public virtual CityHistory CityHistory { get; set; }
    }
}