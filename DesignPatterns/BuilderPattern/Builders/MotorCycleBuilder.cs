using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern.Builders
{
    public class MotorCycleBuilder : VehicleBuilder
    {
        public MotorCycleBuilder()
        {
            Vehicle = new Vehicle("MotorCycle");
        }

        public override void BuildDoors()
        {
            Vehicle["doors"] = "0";
        }

        public override void BuildEngine()
        {
            Vehicle["engine"] = "500 cc";
        }

        public override void BuildFrame()
        {
            Vehicle["frame"] = "Motorcycle frame";
        }

        public override void BuildWheels()
        {
            Vehicle["wheels"] = "2";
        }
    }
}
