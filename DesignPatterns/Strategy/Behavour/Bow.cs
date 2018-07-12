using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.Behavour
{
    public class Bow : WeaponAttack
    {
        private int _damage;
        private int _range;

        public Bow()
        {
            _damage = 10;
            _range = 50;
        }
        public void Attack()
        {
            Console.WriteLine("Attacking, rows hit {0} points within {1} mtrs as a range.", _damage, _range);
        }
    }
}
