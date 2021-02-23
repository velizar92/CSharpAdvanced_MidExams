using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {

        List<Car> data;

        public string Type { get; set; }

        public int Capacity { get; set; }

        public int Count { get { return data.Count; } }

        public Parking(string _type, int _capacity)
        {
            this.Type = _type;
            this.Capacity = _capacity;
            this.data = new List<Car>();
        }

        public void Add(Car car)
        {
            if(Count < Capacity)
            {
                data.Add(car);
            }
        }

        public bool Remove(string _manufacturer, string _model)
        {
            Car removeCar = data
                .FirstOrDefault(c =>
                c.Manufacturer == _manufacturer &&
                c.Model == _model);

            if(removeCar != null)
            {
                data.Remove(removeCar);
                return true;
            }

            return false;
        }

        public Car GetLatestCar()
        {
            Car latestCar = data
                .OrderByDescending(c => c.Year)
                .FirstOrDefault();

            return latestCar;
        }


        public Car GetCar(string _manufacturer, string _model)
        {
            Car car = data
                .FirstOrDefault(c =>
                c.Manufacturer == _manufacturer &&
                c.Model == _model);

            return car;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {this.Type}:");
            foreach(var car in data)
            {
                sb.AppendLine(car.ToString());
            }

            return sb.ToString();
        }




    }
}
