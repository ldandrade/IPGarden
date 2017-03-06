using SQLite;

namespace Irrigatus.Model
{
    public class SensorPanel
    {
        [PrimaryKey]
        public string id { get; set; }
        public string name { get; set; }
        public string hardware { get; set; }
        public bool connected { get; set; }
        public SensorVariables variables { get; set; }
    }
}
