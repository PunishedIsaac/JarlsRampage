using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JarlsRampage
{
    class Villain
    {

        public int villainId { get; set; }

        public string villainName { get; set; }

        public int villainHp { get; set; }

        public int villainBaseDamage { get; set; }

        public int villainAB { get; set; }

        public int villainBaseAC { get; set; }
        public int villainArmorAC { get; set; }

        public int currentHP { get; set; }


        public Villain(int nextVillainId, string nextVillainName, int nextVillainHP, int nextVillainBaseDamage, int nextvillainAttackBonus)
        {
            villainId = nextVillainId;
            villainName = nextVillainName;
            villainHp = nextVillainHP;
            villainBaseDamage = nextVillainBaseDamage;
            villainAB = nextvillainAttackBonus;
            villainBaseAC = 10;
            villainArmorAC = 0;
            currentHP = villainHp;
        }


        //Attacks the player using the roll implementation
        public void VillainTurn(Player p)
        {

            //
            Random rnd = new Random();
            int villainAttackRoll = rnd.Next(1, 21);

            if ((villainAttackRoll + villainAB) < (p.BaseAC + p.Armor))
            {
                Console.WriteLine(villainName + " rolls " + (villainAttackRoll + villainAB) + " against "
                    + p.Name + "'s armorclass of " + (p.BaseAC + p.Armor) + ". " + villainName + " misses.");
            }
            else
            {
                Console.WriteLine(villainName + " rolls " + (villainAttackRoll + villainAB) + " against "
                    + p.Name + "'s armorclass of " + (p.BaseAC + p.Armor) + ". " + villainName + " attacks you for " + villainBaseDamage + " damage.");
                p.Current_hp = p.Current_hp - villainBaseDamage;
                Console.WriteLine(p.Name + " has " + p.Current_hp + " HP left.");
                Console.ReadLine();
            }
          
        }

    }
}
