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

        public void ShowAllVehicle()
        {
            foreach (Moto Motors in Moto)
            {
                Console.WriteLine($"\nMotors:\n" +
                    $"Brand: {Motors.Brand},\n" +
                    $"Model: {Motors.Model},\n" +
                    $"Price: {Motors.Price},\n" +
                    $"KiloMetr: {Motors.KiloMetr}");
            }
        }
        public void SearchByPrice(decimal MinPrice, decimal MaxPrice)
        {
            foreach (Moto Motors in Moto)
            {
                if (Motors.Price >= MinPrice && Motors.Price <= MaxPrice)
                {
                   
                    Console.WriteLine($"\nMotors:\n" +
                                        $"Brand: {Motors.Brand},\n" +
                                        $"Model: {Motors.Model},\n" +
                                        $"Price: {Motors.Price},\n" +
                                        $"KiloMetr: {Motors.KiloMetr}");
                }
            }
        }

        public bool SearchByBrand(string Brand)
        {
            bool valid = false;
            foreach(Moto Motors in Moto)
            {
                if(Motors.Brand == Brand)
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
    }
}
