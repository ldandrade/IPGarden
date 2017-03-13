using SQLite;

namespace Irrigatus.Model
{
    public class WateringEvent
    {
        [PrimaryKey]
        public string guid { get; set; }
        public int stationGUID { get; set; }
        public int wateringTime { get; set; }
        public string startTime { get; set; }
        public string wateringDays { get; set; }
    }
}
