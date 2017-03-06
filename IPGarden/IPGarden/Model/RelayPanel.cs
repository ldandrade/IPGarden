using SQLite;

namespace IPGarden.Model
{
    public class RelayPanel
    {
        [PrimaryKey]
        public string id { get; set; }
        public int return_value { get; set; }
        public string name { get; set; }
        public string hardware { get; set; }
        public bool connected { get; set; }
    }
}
