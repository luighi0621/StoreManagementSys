using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern.Builders
{
    public class ScooterBuilder: VehicleBuilder
    {
        public ScooterBuilder()
        {
            Vehicle = new Vehicle("Scooter");
        }

        public override void BuildDoors()
        {
            Vehicle["doors"] = "0";
        }

        public override void BuildEngine()
        {
            Vehicle["engine"] = "50 cc";
        }

        public override void BuildFrame()
        {
            Vehicle["frame"] = "Scooter frame";
        }

        public override void BuildWheels()
        {
            Vehicle["wheels"] = "3";
        }
    }
}
