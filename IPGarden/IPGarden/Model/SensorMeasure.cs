using SQLite;

namespace Irrigatus.Model
{
    public class SensorMeasure
    {
        public string guid { get; set; }
        public int temperature { get; set; }
        public int humidity { get; set; }
        public string date { get; set; }
        public string time { get; set; }
    }
}
