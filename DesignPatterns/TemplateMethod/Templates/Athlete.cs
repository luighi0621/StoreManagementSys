using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod.Templates
{
    public abstract class Athlete
    {
        protected string Name;

        public Athlete(string name)
        {
            Name = name;
        }

        public void GoToPlace()
        {
            Console.WriteLine("Going to the place");
        }

        public virtual void GetRunning()
        {
            Console.WriteLine("Start running before warm up");
        }

        public abstract void GetWarmUp();
        

        public void Training()
        {
            Console.WriteLine("Starting {0} training", this.GetType().Name);
            GoToPlace();
            GetRunning();
            GetWarmUp();
            Console.WriteLine("Finish training\n");
        }
    }
}
