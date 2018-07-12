using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactory.Products;

namespace AbstractFactory.Factories
{
    public class ColorFactory : Factory
    {
        public override IColor GetColor(string color)
        {
            if (!string.IsNullOrEmpty(color))
            {
                switch (color.ToLower())
                {
                    case "red":
                        return new RedColor();
                    case "blue":
                        return new BlueColor();
                    case "green":
                        return new GreenColor();
                }
            }
            return null;
        }

        public override IShape GetShape(string shape)
        {
            return null;
        }
    }
}
