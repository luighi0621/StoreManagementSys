using Decorator.Accessories;
using Decorator.Laptops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseLaptop ToBuy = new HPLaptop();
            ToBuy = new MouseItem(ToBuy);
            ToBuy = new HeadsetItem(ToBuy);
            ToBuy = new RAMItem(ToBuy, 4);
            Console.WriteLine("{0}\nDescription: {1}\nPrice: {2}", ToBuy.GetName(), ToBuy.GetDescription(), ToBuy.GetPrice());
            Console.ReadKey();
        }
    }
}
