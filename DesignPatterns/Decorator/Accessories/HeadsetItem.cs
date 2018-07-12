using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Decorator.Laptops;

namespace Decorator.Accessories
{
    public class HeadsetItem : ItemAccessory
    {
        public HeadsetItem(BaseLaptop laptop) : base(laptop)
        {
        }

        public override string GetDescription()
        {
            return base.GetDescription() + ", headset added";
        }


        public override int GetPrice()
        {
            return 25 + base.GetPrice();
        }
    }
}
