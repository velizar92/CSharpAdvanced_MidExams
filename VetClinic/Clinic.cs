using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {

        private List<Pet> data;

        public int Capacity { get; set; }

        public int Count { get { return data.Count; } }



        public Clinic(int _capacity)
        {
            this.Capacity = _capacity;
            data = new List<Pet>();
        }


        public void Add(Pet _pet)
        {
            if (this.Count < this.Capacity)
            {
                data.Add(_pet);
            }
        }


        public bool Remove(string _name)
        {
            Pet pet = data.FirstOrDefault(p => p.Name == _name);

            if (pet != null)
            {
                data.Remove(pet);
                return true;
            }

            return false;
        }


        public Pet GetPet(string _name, string _owner)
        {
            Pet pet = data.FirstOrDefault(p => p.Name == _name &&
            p.Owner == _owner);

            return pet;
        }


        public Pet GetOldestPet()
        {
            Pet oldestPet = data.OrderBy(p => p.Age).LastOrDefault();

            return oldestPet;
        }


        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("The clinic has the following patients:");
            foreach (Pet pet in data)
            {                
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return sb.ToString().TrimEnd();

            
        }


    }
}
