using System;
using System.Collections.Generic;
using System.Text;

namespace Parking
{
    public class Car
    {

        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }



        public Car(string _manufacturer, string _model, int _year)
        {
            this.Manufacturer = _manufacturer;
            this.Model = _model;
            this.Year = _year;
        }


        public override string ToString()
        {
            return $"{this.Manufacturer} {this.Model} ({this.Year})";
        }


    }
}
