using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JarlsRampage
{
    class Weapon
    {

        public int weaponId { get; set; }

        public string weaponName { get; set; }

        public int damageBonus { get; set; }

        public int wpnMinBaseDamage { get; set; }

        public int wpnMaxBaseDamage { get; set; }

        public Weapon() { }

        public Weapon(int nextWeaponId, string nextWeaponName, int nextDamageBonus, int nextMinWpnDmg, int nextMaxWpnDamage)
        {

            weaponId = nextWeaponId;
            weaponName = nextWeaponName;
            damageBonus = nextDamageBonus;
            wpnMinBaseDamage = nextMinWpnDmg;
            wpnMaxBaseDamage = nextMaxWpnDamage;
        }
    }
}

