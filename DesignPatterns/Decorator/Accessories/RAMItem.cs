using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Decorator.Laptops;

namespace Decorator.Accessories
{
    public class RAMItem : ItemAccessory
    {
        private int _GB;

        public RAMItem(BaseLaptop laptop, int gb) : base(laptop)
        {
            _GB = gb;
        }

        public override string GetDescription()
        {
            return base.GetDescription() + string.Format(", {0} GB added", _GB);
        }

        public override int GetPrice()
        {
            return base.GetPrice() + 30 * _GB;
        }
    }
}
