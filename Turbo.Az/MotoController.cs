using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turbo.Az
{
    public class MotoController : IVehicleController
    {
        ArrayList Moto;

        public MotoController()
        {
            Moto = new ArrayList();
        }

        public void AddVehicle(Moto Motors)
        {
            Moto.Add(Motors);
        }

        public ArrayList GetVehicles()
        {
            return Moto;
        }

        public void ShowAllVehicle()
        {
            Console.WriteLine("\nMotors:");
            foreach (Moto Motors in Moto)
            {
                Console.WriteLine(
                    $"\nBrand: {Motors.Brand},\n" +
                    $"Model: {Motors.Model},\n" +
                    $"Price: {Motors.Price},\n" +
                    $"KiloMetr: {Motors.KiloMetr}");
            }
        }
        public void SearchByPrice(decimal MinPrice, decimal MaxPrice)
        {
            Console.WriteLine("\nMotors:");
            foreach (Moto Motors in Moto)
            {
                if (Motors.Price >= MinPrice && Motors.Price <= MaxPrice)
                {

                    Console.WriteLine(
                                        $"\nBrand: {Motors.Brand},\n" +
                                        $"Model: {Motors.Model},\n" +
                                        $"Price: {Motors.Price},\n" +
                                        $"KiloMetr: {Motors.KiloMetr}");
                }
            }
        }

        public bool SearchByBrand(string Brand)
        {
            bool valid = false;
            foreach (Moto Motors in Moto)
            {
                if (Motors.Brand == Brand)
                {
                    valid = true;
                    Console.Clear();
                    Console.WriteLine($"\nMotors:\n" +
                    $"Brand: {Motors.Brand},\n" +
                    $"Model: {Motors.Model},\n" +
                    $"Price: {Motors.Price},\n" +
                    $"KiloMetr: {Motors.KiloMetr}");
                }
            }
            return valid;
        }

        public bool SearchByModel(string Model)
        {
            bool valid = false;
            foreach (Moto Motors in Moto)
            {
                if (Motors.Model == Model)
                {
                    valid = true;
                    Console.Clear();
                    Console.WriteLine($"\nMotors:\n" +
                    $"Brand: {Motors.Brand},\n" +
                    $"Model: {Motors.Model},\n" +
                    $"Price: {Motors.Price},\n" +
                    $"KiloMetr: {Motors.KiloMetr}");
                }
            }
            return valid;
        }

        public  void ShowByPriceLow()
        {
          
            for (int i = 0; i < Moto.Count - 1; i++)
            {
                for (int j = 0; j < Moto.Count - 1 - i; j++)
                {
                    Moto current = (Moto)Moto[j];
                    Moto next = (Moto)Moto[j + 1];

                    if (current.Price > next.Price)
                    {
                        
                        Moto[j] = next;
                        Moto[j + 1] = current;
                    }
                }
            }
            Console.WriteLine("\nMotors:");
            foreach (Moto motor in Moto)
            {
                Console.WriteLine(
                                  $"\nBrand: {motor.Brand},\n" +
                                  $"Model: {motor.Model},\n" +
                                  $"Price: {motor.Price},\n " +
                                  $"KiloMetr: {motor.KiloMetr},\n" +
                                  $"Category: {motor.Category}");
            }
        }

        public void ShowByPriceHight()

        {

            for (int i = 0; i < Moto.Count - 1; i++)
            {
                for (int j = 0; j < Moto.Count - 1 - i; j++)
                {
                    Moto current = (Moto)Moto[j];
                    Moto next = (Moto)Moto[j + 1];

                    if (current.Price < next.Price)
                    {

                        Moto[j] = next;
                        Moto[j + 1] = current;
                    }
                }
            }
            Console.WriteLine("\nMotors:");
            foreach (Moto motor in Moto)
            {
                Console.WriteLine(
                                  $"\nBrand: {motor.Brand},\n" +
                                  $"Model: {motor.Model},\n" +
                                  $"Price: {motor.Price},\n " +
                                  $"KiloMetr: {motor.KiloMetr},\n" +
                                  $"Category: {motor.Category}");
            }
        }

        public void SearcByKm(decimal MinKm, decimal MaxKm)
        {

            Console.WriteLine("\nMotors:");
            foreach (Moto Motors in Moto)
            {
                if (Motors.KiloMetr >= MinKm && Motors.KiloMetr <= MaxKm)
                {

                    Console.WriteLine(
                                        $"\nBrand: {Motors.Brand},\n" +
                                        $"Model: {Motors.Model},\n" +
                                        $"Price: {Motors.Price},\n" +
                                        $"KiloMetr: {Motors.KiloMetr}");
                }
            }
        }

        public void AddNewVehicle(string Brand, string Model, decimal Price, decimal KiloMetr , VehicleCategory catgeory)
        {
            Moto NeWmoto = new Moto(Brand, Model, Price, KiloMetr, VehicleCategory.Moto);

            Moto.Add(NeWmoto);
        }

        public void UpdateVehicle(int Index, Ivehicle Updated)
        {
            Moto[Index - 1] = Updated;
        }

        public void RemoveVehicle(int Index)
        {
            Moto.RemoveAt(Index - 1);
        }
    }
}






/*
    []

    []
    []
 
 */