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

        public RelayPanel(int return_value, string id, string name, string hardware, bool connected)
        {
            this.return_value = return_value;
            this.id = id;
            this.name = name;
            this.hardware = hardware;
            this.connected = connected;
        }
    }
}
