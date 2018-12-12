using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinic.Classes
{
    public class Pet
    {
        private string name;

        private int age;

        private string kind;

        public Pet()
        {
        }

        public Pet(string name, int age, string kind)
        {
            this.Name = name;
            this.Age = age;
            this.Kind = kind;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public string Kind
        {
            get { return this.kind; }
            set { this.kind = value; }
        }
    }
}
