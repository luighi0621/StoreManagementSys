using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Products
{
    public class Rectangle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Drawing circle with 5 and 8 of sides");
        }
    }
}
