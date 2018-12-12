namespace PetClinic.Classes
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ListOfRooms<Room> : IEnumerable<Room>
    {
        private readonly List<Room> data;

        public ListOfRooms()
        {
            this.data = new List<Room>();
        }

        public void Add(Room item)
        {
            this.data.Add(item);
        }

        public int Count()
        {
            return this.data.Count();
        }

        public Room this[int index]
        {
            get
            {
                return this.data[index];
            }
        }


        public IEnumerator<Room> GetEnumerator()
        {

            int firstIndex = (this.data.Count() - 1) / 2;

            for (int i = 0; firstIndex + i < data.Count(); i++)
            {
                if (i != 0)
                {
                    yield return this.data[firstIndex - i];
                    yield return this.data[firstIndex + i];
                }
                else
                {
                    yield return this.data[firstIndex];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

    }
}
