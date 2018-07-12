using Strategy.Behavour;
using Strategy.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            Player playerOne = new Player("Jose");
            playerOne.Attack();
            playerOne.ChangeWeaponAttack(new LongSword());
            playerOne.Attack();
            playerOne.Attack();
            playerOne.ChangeWeaponAttack(new Bow());
            playerOne.Attack();
            Console.ReadKey();
        }
    }
}
