using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern.Builders
{
    public class CarBuilder: VehicleBuilder
    {
        public CarBuilder()
        {
            Vehicle = new Vehicle("Car");
        }
        public override void BuildDoors()
        {
            Vehicle["doors"] = "4";
        }

        public override void BuildEngine()
        {
            Vehicle["engine"] = "2500 cc";
        }

        public override void BuildFrame()
        {
            Vehicle["frame"] = "Car frame";
        }

        public override void BuildWheels()
        {
            Vehicle["wheels"] = "4";
        }
    }
}
