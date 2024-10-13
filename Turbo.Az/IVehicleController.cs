using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turbo.Az
{
    public interface IVehicleController
    {
        void ShowAllVehicle();
        ArrayList GetVehicles();
        void SearchByPrice(decimal MinPrice, decimal MaxPrice);
        bool SearchByBrand(string Brand);
        bool SearchByModel(string Model);
        void ShowByPriceLow();
        void ShowByPriceHight();
        void SearcByKm(decimal MinKm, decimal MaxKm);
        void AddNewVehicle(string Brand, string Model, decimal Price, decimal KiloMetr, VehicleCategory catgeory);
        void UpdateVehicle(int Index, Ivehicle Updated);
        void RemoveVehicle(int Index);
    }
}
