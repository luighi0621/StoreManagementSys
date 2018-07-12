using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod.Templates
{
    public class BasketballAthlete : Athlete
    {
        public BasketballAthlete(string name) : base(name)
        {
        }

        public override void GetWarmUp()
        {
            Console.WriteLine("start shooting ball from 3 points");
            Console.WriteLine("throw ball from sinle point");
            Console.WriteLine("throw ball from double point");
            Console.WriteLine("enter to lay-up");
        }
    }
}
