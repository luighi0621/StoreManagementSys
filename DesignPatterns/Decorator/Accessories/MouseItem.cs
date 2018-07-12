using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Decorator.Laptops;

namespace Decorator.Accessories
{
    public class MouseItem : ItemAccessory
    {
        public MouseItem(BaseLaptop laptop) : base(laptop)
        {
        }

        public override string GetDescription()
        {
            return base.GetDescription() + ", mouse added";
        }

        public override int GetPrice()
        {
            return 50 + base.GetPrice();
        }
    }
}
