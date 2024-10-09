using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turbo.Az
{
    public class TruckController : IVehicleController
    {
        ArrayList Truck;

        public TruckController()
        {
            Truck = new ArrayList();
        }

        public void AddVehicle(Truck trukcs)
        {
            Truck.Add(trukcs);
        }

        public void ShowAllVehicle()
        {
            foreach (Truck Trucks in Truck)
            {
                Console.WriteLine($"\nTrucks:\n" +
                    $"Brand: {Trucks.Brand},\n" +
                    $"Model: {Trucks.Model},\n" +
                    $"Price: {Trucks.Price},\n" +
                    $"KiloMetr: {Trucks.KiloMetr}");
            }
        }



        public void SearchByPrice(decimal MinPrice, decimal MaxPrice)
        {
            foreach (Truck Trucks in Truck)
            {
                if (Trucks.Price >= MinPrice && Trucks.Price <= MaxPrice)
                {
                    Console.WriteLine($"\nMotors:\n" +
                                        $"Brand: {Trucks.Brand},\n" +
                                        $"Model: {Trucks.Model},\n" +
                                        $"Price: {Trucks.Price},\n" +
                                        $"KiloMetr: {Trucks.KiloMetr}");
                }
            }
        }


        public bool SearchByBrand(string Brand)
        {
            bool valid = false;
            foreach (Truck Trucks in Truck)
            {
                if (Trucks.Brand == Brand)
                {
                    valid = true;
                    Console.Clear();

                    Console.WriteLine($"\nMotors:\n" +
                    $"Brand: {Trucks.Brand},\n" +
                    $"Model: {Trucks.Model},\n" +
                    $"Price: {Trucks.Price},\n" +
                    $"KiloMetr: {Trucks.KiloMetr}");
                }
            }
            return valid;
        }

        public bool SearchByModel(string Model)
        {
            bool valid = false;
            foreach (Truck Trucks in Truck)
            {
                if (Trucks.Model == Model)
                {
                    valid = true;
                    Console.Clear();

                    Console.WriteLine($"\nMotors:\n" +
                    $"Brand: {Trucks.Brand},\n" +
                    $"Model: {Trucks.Model},\n" +
                    $"Price: {Trucks.Price},\n" +
                    $"KiloMetr: {Trucks.KiloMetr}");
                }
            }
            return valid;
        }
    }
}
