using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Products
{
    public class BlueColor : IColor
    {
        public void Fill()
        {
            Console.WriteLine("Filling with {0}", this.GetType().Name);
        }
    }
}
