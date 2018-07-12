using Decorator.Laptops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.Accessories
{
    public abstract class ItemAccessory: BaseLaptop
    {
        protected BaseLaptop _Laptop;

        public ItemAccessory(BaseLaptop laptop)
        {
            _Laptop = laptop;
        }

        public override sealed string GetName()
        {
            return _Laptop.GetName();
        }
        public override int GetPrice()
        {
            return _Laptop.GetPrice();
        }

        public override string GetDescription()
        {
            return _Laptop.GetDescription();
        }
    }
}
