using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    internal class Person
    {

        private string pin;

        public string Pin
        {
            get { return pin; }
            set { pin = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public Person(string pin, string name)
        {
            pin = pin;
            name = name;
        }

    }
}
