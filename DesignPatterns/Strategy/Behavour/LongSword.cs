using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.Behavour
{
    public class LongSword : WeaponAttack
    {
        private int _damage;

        public LongSword()
        {
            _damage = 130;
        }

        public void Attack()
        {
            Console.WriteLine("Attacking, hit damage {0} points.", _damage); ;
        }
    }
}
