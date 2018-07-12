namespace Prototype
{
    public abstract class ItemPrototype
    {
        protected double Weidth;
        protected double Height;
        protected double Depth;
        public abstract ItemPrototype Clone();

        public void Display()
        {
            System.Console.WriteLine("Item...\nHeigh: {0}\nWeidth:{1}\nDepth:{2}\n", Height, Weidth, Depth);
        }
    }
}