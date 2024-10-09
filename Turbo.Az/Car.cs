using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turbo.Az
{
    public class Car : Ivehicle
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public decimal KiloMetr { get; set; }
        public VehicleCategory Category { get; set; }


        public Car(string brand,
                    string model,
                    decimal price,
                    decimal Kilometr,
                    VehicleCategory category)
        {
            Brand = brand;
            Model = model;
            Price = price;
            KiloMetr = Kilometr;
            Category = category;
        }


        public void GetInfo()
        {

        }
        public void Update()
        {

        }
    }
}
