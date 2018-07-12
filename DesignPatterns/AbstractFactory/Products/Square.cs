using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Products
{
    public class Square : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Drawing Square with 5 of sides");
        }
    }
}
