using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {

        List<Employee> data;

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count { get { return data.Count; } }

        public Bakery(string _name, int _capacity)
        {
            this.Name = _name;
            this.Capacity = _capacity;
            data = new List<Employee>();
        }

        public void Add(Employee _employee)
        {
            if(this.Count < this.Capacity)
            {
                data.Add(_employee);
            }
        }

        public bool Remove(string _name)
        {
            Employee employee = data.FirstOrDefault(e => e.Name == _name);

            if(employee != null)
            {
                data.Remove(employee);
                return true;
            }

            return false;
        }

        public Employee GetOldestEmployee()
        {
            Employee oldestEmployee = data.OrderByDescending(e => e.Age).FirstOrDefault();

            return oldestEmployee;

        }

        public Employee GetEmployee(string _name)
        {
            Employee employee = data.FirstOrDefault(e => e.Name == _name);

            return employee;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Employees working at Bakery {this.Name}:");
            foreach(Employee employee in data)
            {
                sb.AppendLine(employee.ToString());
            }

            return sb.ToString().TrimEnd();
        }







    }
}
