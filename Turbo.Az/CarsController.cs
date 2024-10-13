using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turbo.Az
{
    public class CarsController : IVehicleController
    {
        ArrayList Cars;

        public CarsController()
        {
            Cars = new ArrayList();
        }

        public void AddVehicle(Car cars)
        {
            Cars.Add(cars);
        }

        public ArrayList GetVehicles()
        {
            return Cars;
        }

        public void ShowAllVehicle()
        {
            Console.WriteLine("\nCars:");
            foreach (Car Cars in Cars)
            {
                Console.WriteLine(
                    $"\nBrand: {Cars.Brand},\n" +
                    $"Model: {Cars.Model},\n" +
                    $"Price: {Cars.Price},\n" +
                    $"KiloMetr: {Cars.KiloMetr}");
            }
        }



        public void SearchByPrice(decimal MinPrice, decimal MaxPrice)
        {
            Console.WriteLine("\nCars:");
            foreach (Car Cars in Cars)
            {
                if (Cars.Price >= MinPrice && Cars.Price <= MaxPrice)
                {
                    Console.WriteLine(
                                        $"\nBrand: {Cars.Brand},\n" +
                                        $"Model: {Cars.Model},\n" +
                                        $"Price: {Cars.Price},\n" +
                                        $"KiloMetr: {Cars.KiloMetr}");
                }
            }
        }


        public bool SearchByBrand(string Brand)
        {
            bool valid = false;
            foreach (Car Cars in Cars)
            {
                if (Cars.Brand == Brand)
                {
                    valid = true;
                    Console.Clear();

                    Console.WriteLine($"Cars:\n"+
                    $"Brand: {Cars.Brand},\n" +
                    $"Model: {Cars.Model},\n" +
                    $"Price: {Cars.Price},\n" +
                    $"KiloMetr: {Cars.KiloMetr}");
                }
            }
            return valid;
        }

        public bool SearchByModel(string Model) 
        {
            bool valid = false;
            foreach (Car Cars in Cars)
            {
                if (Cars.Model == Model)
                {
                    valid = true;
                    Console.Clear();

                    Console.WriteLine($"Cars:"+
                    $"Brand: {Cars.Brand},\n" +
                    $"Model: {Cars.Model},\n" +
                    $"Price: {Cars.Price},\n" +
                    $"KiloMetr: {Cars.KiloMetr}");
                }
            }
            return valid;
        }

        public void ShowByPriceLow()
        {

            for (int i = 0; i < Cars.Count - 1; i++)
            {
                for (int j = 0; j < Cars.Count - 1 - i; j++)
                {
                    Car current = (Car)Cars[j];
                    Car next = (Car)Cars[j + 1];

                    if (current.Price > next.Price)
                    {

                        Cars[j] = next;
                        Cars[j + 1] = current;
                    }
                }
            }
            Console.WriteLine("\nCars:");
            foreach (Car Car in Cars)
            {
                Console.WriteLine(
                                  $"\nBrand: {Car.Brand},\n" +
                                  $"Model: {Car.Model},\n" +
                                  $"Price: {Car.Price},\n " +
                                  $"KiloMetr: {Car.KiloMetr},\n" +
                                  $"Category: {Car.Category}");
            }
        }


        public void ShowByPriceHight()
        {
            for (int i = 0; i < Cars.Count - 1; i++)
            {
                for (int j = 0; j < Cars.Count - 1 - i; j++)
                {
                    Car current = (Car)Cars[j];
                    Car next = (Car)Cars[j + 1];

                    if (current.Price < next.Price)
                    {

                        Cars[j] = next;
                        Cars[j + 1] = current;
                    }
                }
            }
            Console.WriteLine("\nCars:");
            foreach (Car Car in Cars)
            {
                Console.WriteLine(
                                  $"\nBrand: {Car.Brand},\n" +
                                  $"Model: {Car.Model},\n" +
                                  $"Price: {Car.Price},\n " +
                                  $"KiloMetr: {Car.KiloMetr},\n" +
                                  $"Category: {Car.Category}");
            }
        }

        public void SearcByKm(decimal MinKm, decimal MaxKm)
        {
            Console.WriteLine("\nCars:");
            foreach (Car Cars in Cars)
            {
                if (Cars.Price >= MinKm && Cars.Price <= MaxKm)
                {
                    Console.WriteLine(
                                        $"\nBrand: {Cars.Brand},\n" +
                                        $"Model: {Cars.Model},\n" +
                                        $"Price: {Cars.Price},\n" +
                                        $"KiloMetr: {Cars.KiloMetr}");
                }
            }
        }

        public void AddNewVehicle(string Brand, string Model, decimal Price, decimal KiloMetr, VehicleCategory catgeory)
        {
            Car NeWCar = new(Brand, Model, Price, KiloMetr, VehicleCategory.Car);

            Cars.Add(NeWCar);
        }

        public void UpdateVehicle(int Index, Ivehicle Updated)
        {
            Cars[Index - 1] = Updated;
        }

        public void RemoveVehicle(int Index)
        {
            Cars.RemoveAt(Index - 1);
        }
    }
}

