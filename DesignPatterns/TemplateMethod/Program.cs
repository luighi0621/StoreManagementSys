using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateMethod.Templates;

namespace TemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Athlete playerOne = new BasketballAthlete("Pepe");
            playerOne.Training();

            Athlete playerTwo = new SwimAthlete("Karen");
            playerTwo.Training();

            Console.ReadKey();
        }
    }
}
