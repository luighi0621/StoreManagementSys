using AbstractFactory.Factories;
using AbstractFactory.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Factory shapeFact = Producer.GetFactory("shape");

            IShape circle = shapeFact.GetShape("circle");
            circle.Draw();

            IShape rectangle = shapeFact.GetShape("rectangle");
            rectangle.Draw();

            Factory colorFactory = Producer.GetFactory("color");

            IColor blueColor = colorFactory.GetColor("blue");
            blueColor.Fill();

            IColor redColor = colorFactory.GetColor("red");
            redColor.Fill();

            Console.ReadKey();
        }
    }
}
