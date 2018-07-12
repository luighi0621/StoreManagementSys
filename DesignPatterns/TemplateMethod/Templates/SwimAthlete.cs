using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod.Templates
{
    public class SwimAthlete : Athlete
    {
        public SwimAthlete(string name) : base(name)
        {
        }

        public override void GetRunning()
        {
            Console.WriteLine("No running needed"); ;
        }

        public override void GetWarmUp()
        {
            Console.WriteLine("Start swimming 2 rounds free style");
            Console.WriteLine("Swim 3 rounds chest style");
            Console.WriteLine("Swim 2 rounds butterfly style");
            Console.WriteLine("Swim single round back style");
        }
    }
}
