namespace Prototype
{
    internal class Item : ItemPrototype
    {
        public Item(double v1, double v2, double v3)
        {
            this.Height = v1;
            this.Weidth = v2;
            this.Depth = v3;
        }

        public override ItemPrototype Clone()
        {
            System.Console.WriteLine("Cloning item...\nHeigh: {0}\nWeidth:{1}\nDepth:{2}\n", Height, Weidth, Depth);
            return this.MemberwiseClone() as ItemPrototype;
        }

        public void SetHeight(double h)
        {
            System.Console.WriteLine("setting height from {0} to {1}...", Height, h);
            Height = h;
        }
    }
}