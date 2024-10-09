using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turbo.Az
{
    public interface IVehicleController
    {
        void ShowAllVehicle();
        void SearchByPrice(decimal MinPrice, decimal MaxPrice);
        bool SearchByBrand(string Brand);
        bool SearchByModel(string Model);
    }
}
