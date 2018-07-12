using BuilderPattern.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            VehicleBuilder builder;

            Shop shop = new Shop();

            builder = new ScooterBuilder();
            shop.Build(builder);
            builder.Vehicle.Show();

            builder = new CarBuilder();
            shop.Build(builder);
            builder.Vehicle.Show();

            builder = new MotorCycleBuilder();
            shop.Build(builder);
            builder.Vehicle.Show();

            Console.ReadKey();
        }
    }
}
