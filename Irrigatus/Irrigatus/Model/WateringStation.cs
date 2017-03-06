using SQLite;

namespace Irrigatus.Model
{
    public class WateringStation
    {
        [PrimaryKey]
        public string guid { get; set; }
        public int number { get; set; }
        public string name { get; set; }
        public bool active { get; set; }
        public int wateringTime { get; set; }
        public string fullName { get; set; }
    }
}
