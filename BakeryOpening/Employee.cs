using System;
using System.Collections.Generic;
using System.Text;

namespace BakeryOpenning
{
    public class Employee
    {

        public string Name { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }

        public Employee(string _name, int _age, string _country)
        {
            this.Name = _name;
            this.Age = _age;
            this.Country = _country;
        }

        public override string ToString()
        {
            return $"Employee: {this.Name}, {this.Age} ({this.Country})";
        }



    }
}
