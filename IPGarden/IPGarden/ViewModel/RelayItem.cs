using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPGarden.ViewModel
{
    class RelayItem
    {
        private int return_value;
        private string id;
        private string name;
        private string hardware;
        private bool connected;

        public RelayItem(int return_value, string id, string name, string hardware, bool connected)
        {
            this.return_value = return_value;
            this.id = id;
            this.name = name;
            this.hardware = hardware;
            this.connected = connected;
        }

        public int Return_value
        {
            get
            {
                return return_value;
            }

            set
            {
                return_value = value;
            }
        }

        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Hardware
        {
            get
            {
                return hardware;
            }

            set
            {
                hardware = value;
            }
        }

        public bool Connected
        {
            get
            {
                return connected;
            }

            set
            {
                connected = value;
            }
        }
    }
}
