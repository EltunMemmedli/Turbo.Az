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

        public ArrayList GetVehicles()
        {
            return Truck;
        }

        public void ShowAllVehicle()
        {
            Console.WriteLine("\nTrucks:");
            foreach (Truck Trucks in Truck)
            {
                Console.WriteLine(
                    $"\nBrand: {Trucks.Brand},\n" +
                    $"Model: {Trucks.Model},\n" +
                    $"Price: {Trucks.Price},\n" +
                    $"KiloMetr: {Trucks.KiloMetr}");
            }
        }



        public void SearchByPrice(decimal MinPrice, decimal MaxPrice)
        {
            Console.WriteLine("\nTrucks:");
            foreach (Truck Trucks in Truck)
            {
                if (Trucks.Price >= MinPrice && Trucks.Price <= MaxPrice)
                {
                    Console.WriteLine(
                                        $"\nBrand: {Trucks.Brand},\n" +
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

                    Console.WriteLine($"Trucks:\n"+
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

                    Console.WriteLine($"Trucks\n" +
                    $"Brand: {Trucks.Brand},\n" +
                    $"Model: {Trucks.Model},\n" +
                    $"Price: {Trucks.Price},\n" +
                    $"KiloMetr: {Trucks.KiloMetr}");
                }
            }
            return valid;
        }

        public void ShowByPriceLow()
        {

            for (int i = 0; i < Truck.Count - 1; i++)
            {
                for (int j = 0; j < Truck.Count - 1 - i; j++)
                {
                    Truck current = (Truck)Truck[j];
                    Truck next = (Truck)Truck[j + 1];

                    if (current.Price > next.Price)
                    {

                        Truck[j] = next;
                        Truck[j + 1] = current;
                    }
                }
            }
            Console.WriteLine("\nTrucks:");
            foreach (Truck Trucks in Truck)
            {
                Console.WriteLine(
                                  $"\nBrand: {Trucks.Brand},\n" +
                                  $"Model: {Trucks.Model},\n" +
                                  $"Price: {Trucks.Price},\n " +
                                  $"KiloMetr: {Trucks.KiloMetr},\n" +
                                  $"Category: {Trucks.Category}");
            }
        }

        public void ShowByPriceHight()
        {

            for (int i = 0; i < Truck.Count - 1; i++)
            {
                for (int j = 0; j < Truck.Count - 1 - i; j++)
                {
                    Truck current = (Truck)Truck[j];
                    Truck next = (Truck)Truck[j + 1];

                    if (current.Price < next.Price)
                    {

                        Truck[j] = next;
                        Truck[j + 1] = current;
                    }
                }
            }
            Console.WriteLine("\nTrucks:");
            foreach (Truck Trucks in Truck)
            {
                Console.WriteLine(
                                  $"\nBrand: {Trucks.Brand},\n" +
                                  $"Model: {Trucks.Model},\n" +
                                  $"Price: {Trucks.Price},\n " +
                                  $"KiloMetr: {Trucks.KiloMetr},\n" +
                                  $"Category: {Trucks.Category}");
            }
        }

        public void SearcByKm(decimal MinKm, decimal MaxKm)
        {
            Console.WriteLine("\nTrucks:");
            foreach (Truck Trucks in Truck)
            {
                if (Trucks.Price >= MinKm && Trucks.Price <= MaxKm)
                {

                    Console.WriteLine(
                                        $"\nBrand: {Trucks.Brand},\n" +
                                        $"Model: {Trucks.Model},\n" +
                                        $"Price: {Trucks.Price},\n" +
                                        $"KiloMetr: {Trucks.KiloMetr}");
                }
            }
        }

        public void AddNewVehicle(string Brand, string Model, decimal Price, decimal KiloMetr, VehicleCategory catgeory)
        {
            Truck NeWTruck = new(Brand, Model, Price, KiloMetr, VehicleCategory.Truck);

            Truck.Add(NeWTruck);
        }

        public void UpdateVehicle(int Index, Ivehicle Updated)
        {
            Truck[Index - 1] = Updated;
        }

        public void RemoveVehicle(int Index)
        {
            Truck.RemoveAt(Index - 1);
        }
    }
}
