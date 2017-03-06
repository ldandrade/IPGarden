using SQLite;

namespace IPGarden.Model
{
    public class WateringStation
    {
        [PrimaryKey]
        public int guid { get; set; }
        public int number { get; set; }
        public string name { get; set; }
        public bool active { get; set; }
        public int wateringTime { get; set; }
        public string fullName { get; set; }

        public WateringStation(string name, int number, bool active, int wateringTime)
        {
            this.number = number;
            this.name = name;
            this.active = active;
            this.wateringTime = wateringTime;
            this.fullName = string.Concat(number, " - ", name);
        }
    }
}
