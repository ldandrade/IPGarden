using SQLite;

namespace IPGarden.Model
{
    public class WateringEvent
    {
        [PrimaryKey]
        public string guid { get; set; }
        public int stationNumber { get; set; }
        public string stationName { get; set; }
        public int wateringTime { get; set; }
        public string startTime { get; set; }
        public string wateringDays { get; set; }
        public string stationFullName { get; set; }
    }
}
