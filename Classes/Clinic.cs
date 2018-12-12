namespace PetClinic.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Clinic
    {
        private string name;

        private int numberOfRooms;

        private ListOfRooms<Room> listOfRooms;

        public Clinic()
        {
        }

        public Clinic(string name, int numberOfRooms, ListOfRooms<Room> listOfRooms)
        {
            this.Name = name;
            this.NumberOfRooms = numberOfRooms;
            this.listOfRooms = listOfRooms;
        }


        public string Name
        {
            get { return this.name; }

            set { this.name = value; }
        }

        public int NumberOfRooms
        {
            get { return this.numberOfRooms; }
            private set
            {
                if (value % 2 == 0)
                {
                    throw new ArgumentException("Invalid Operation");
                }
                else
                {
                    this.numberOfRooms = value;
                }
                
            }
        }

        public ListOfRooms<Room> ListOfRooms
        {
            get { return this.listOfRooms; }
            set { this.listOfRooms = new ListOfRooms<Room>(); }

        }
    }
}
