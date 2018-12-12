namespace PetClinic.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Room
    {
        private int number;

        private Pet pet;

        public Room()
        {
            this.Number = number;
            this.Pet = pet;
        }

        public int Number
        {
            get { return this.number; }
            set { this.number = value; }
        }

        public Pet Pet
        {
            get { return this.pet; }
            set { this.pet = value; }
        }

        public bool IsEmty()
        {
            if (this.pet == null)
            {
                return true;
            }
            return false;
        }
    }
}
