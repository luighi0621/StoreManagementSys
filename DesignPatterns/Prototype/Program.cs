using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            ItemManager itemManager = new ItemManager();
            Item door = new Item(1.70, 1, 0.5);
            door.Display();
            itemManager["door"] = door;

            Item doorTwo = door;
            doorTwo.Display();

            door.SetHeight(2);
            door.Display();
            doorTwo.Display();

            Item item1 = itemManager["door"].Clone() as Item;
            door.SetHeight(3);
            door.Display();
            doorTwo.Display();
            item1.Display();
            Console.ReadKey();
        }
    }
}
