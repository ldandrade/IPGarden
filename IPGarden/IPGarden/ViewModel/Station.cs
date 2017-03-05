using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPGarden.ViewModel
{
    class Station
    {
        private String name;
        private int id;
        private bool active;
        private int wateringTime;
        private string fullName;

        public Station(string name, int number, bool active, int wateringTime)
        {
            this.name = name;
            this.id = number;
            this.active = active;
            this.WateringTime = wateringTime;
            this.FullName = string.Concat(id, " - ", name);
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

        public int Number
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

        public bool Active
        {
            get
            {
                return active;
            }

            set
            {
                active = value;
            }
        }

        public int WateringTime
        {
            get
            {
                return wateringTime;
            }

            set
            {
                wateringTime = value;
            }
        }

        public string FullName
        {
            get
            {
                return fullName;
            }

            set
            {
                fullName = value;
            }
        }
    }
}
