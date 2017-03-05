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
        private int number;
        private bool active;
        private int wateringTime;

        public Station(string name, int number, bool active, int wateringTime)
        {
            this.name = name;
            this.number = number;
            this.active = active;
            this.WateringTime = wateringTime;
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
                return number;
            }

            set
            {
                number = value;
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
    }
}
