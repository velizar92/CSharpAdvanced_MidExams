using System;
using System.Collections.Generic;
using System.Text;

namespace VetClinic
{
    public class Pet
    {

        public string Name { get; set; }
        public int Age { get; set; }
        public string Owner { get; set; }

        public Pet(string _name, int _age, string _owner)
        {
            this.Name = _name;
            this.Age = _age;
            this.Owner = _owner;
        }

        public override string ToString()
        {
            return $"Name: {this.Name} Age: {this.Age} Owner: {this.Owner}";
        }





    }
}
