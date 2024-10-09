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

        public void ShowAllVehicle()
        {
            foreach (Car Cars in Cars)
            {
                Console.WriteLine($"Cars:\n" +
                    $"Brand: {Cars.Brand},\n" +
                    $"Model: {Cars.Model},\n" +
                    $"Price: {Cars.Price},\n" +
                    $"KiloMetr: {Cars.KiloMetr}");
            }
        }



        public void SearchByPrice(decimal MinPrice, decimal MaxPrice)
        {
            foreach (Car Cars in Cars)
            {
                if (Cars.Price >= MinPrice && Cars.Price <= MaxPrice)
                {
                    Console.WriteLine($"\nMotors:\n" +
                                        $"Brand: {Cars.Brand},\n" +
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

                    Console.WriteLine($"\nMotors:\n" +
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

                    Console.WriteLine($"\nMotors:\n" +
                    $"Brand: {Cars.Brand},\n" +
                    $"Model: {Cars.Model},\n" +
                    $"Price: {Cars.Price},\n" +
                    $"KiloMetr: {Cars.KiloMetr}");
                }
            }
            return valid;
        }
    }
}
