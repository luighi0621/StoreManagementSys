using Decorator.Accessories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.Laptops
{
    public abstract class BaseLaptop
    {
        protected int price = 1500;

        protected string Description = "Basic Computer";
        protected string Name = "";
        public virtual int GetPrice()
        {
            return price;
        }

        public virtual string GetName()
        {
            return Name;
        }

        public virtual string GetDescription()
        {
            return Description;
        }
    }
}
