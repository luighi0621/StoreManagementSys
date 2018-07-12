using Strategy.Behavour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.Client
{
    public class Player
    {
        private WeaponAttack Weapon;

        public Player(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public void Attack()
        {
            if (Weapon == null)
            {
                Console.WriteLine("No item to attack!");
                return;
            }
            Weapon.Attack();
        }

        public void ChangeWeaponAttack(WeaponAttack newWeapon)
        {
            Weapon = newWeapon;
        }
    }
}
