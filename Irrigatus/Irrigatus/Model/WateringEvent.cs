using SQLite;

namespace Irrigatus.Model
{
    public class WateringEvent
    {
        [PrimaryKey]
        public string guid { get; set; }
        public string stationFullName { get; set; }
        public int wateringTime { get; set; }
        public string startTime { get; set; }
        public bool sunday { get; set; }
        public bool monday { get; set; }
        public bool tuesday { get; set; }
        public bool wednesday { get; set; }
        public bool thursday { get; set; }
        public bool friday { get; set; }
        public bool saturday { get; set; }
    }
}
