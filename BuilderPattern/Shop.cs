using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuilderPattern.Builders;

namespace BuilderPattern
{
    public class Shop
    {
        public Vehicle Build(VehicleBuilder vehicle)
        {
            vehicle.BuildFrame();
            vehicle.BuildEngine();
            vehicle.BuildDoors();
            vehicle.BuildWheels();
            return vehicle.Vehicle;
        }
    }
}
