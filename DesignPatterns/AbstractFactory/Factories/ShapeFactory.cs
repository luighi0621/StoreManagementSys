using AbstractFactory.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Factories
{
    public class ShapeFactory : Factory
    {
        public override IColor GetColor(string color)
        {
            return null;
        }

        public override IShape GetShape(string shape)
        {
            if (!string.IsNullOrEmpty(shape))
            {
                switch (shape.ToLower())
                {
                    case "circle":
                        return new Circle();
                    case "square":
                        return new Square();
                    case "rectangle":
                        return new Rectangle();
                }
            }
            return null;
        }
    }
}
