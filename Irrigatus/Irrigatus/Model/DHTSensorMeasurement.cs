namespace Irrigatus.Model
{
    class DHTSensorMeasurement
    {
        public int return_value { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string hardware { get; set; }
        public bool connected { get; set; }
    }
}
