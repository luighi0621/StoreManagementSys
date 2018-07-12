using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Factories
{
    public static class Producer
    {
        public static Factory GetFactory(string factoryType)
        {
            switch (factoryType.ToLower())
            {
                case "color":
                    return new ColorFactory();
                case "shape":
                    return new ShapeFactory();
            }
            return null;
        }
    }
}
