using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPGarden.ViewModel
{
    class HumSensor
    {
        private int humidity;
        private string id;
        private string name;
        private string hardware;
        private bool connected;

        public HumSensor(int humidity, string id, string name, string hardware, bool connected)
        {
            this.humidity = humidity;
            this.id = id;
            this.name = name;
            this.hardware = hardware;
            this.connected = connected;
        }

        public int Humidity
        {
            get
            {
                return humidity;
            }

            set
            {
                humidity = value;
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
