﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turbo.Az
{
    public interface Ivehicle
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public decimal KiloMetr { get; set; }
        public VehicleCategory Category { get; set; }

        public void GetInfo();
        public void Update();
    }
}
