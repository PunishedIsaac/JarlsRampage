using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JarlsRampage
{
    class Player
    {
        private string name;
        public string Name { get { return name; } set { name = value; } }

        private int max_hp;
        public int Max_hp { get { return max_hp; } set { max_hp = value; } }

        private int current_hp;
        public int Current_hp { get { return current_hp; } set { current_hp = value; } }

        private int damage;
        public int Damage { get { return damage; } set { damage = value; } }

        private int armor;
        public int Armor { get { return armor; } set { armor = value; } }

        private int constitution;
        public int Constitution { get { return constitution; } set { constitution = value; } }

        private string job;
        public string Job { get { return job; } set { job = value; } }

        private int lvl { get; set; }
        public int Lvl { get { return lvl; } set { lvl = value; } }

        private Boolean def;
        public Boolean Def { get { return def; } set { def = value; } }

        public Weapon wpn;

        private int baseAC;
        public int BaseAC { get { return baseAC; } set { baseAC = value; } }

        private int ab;
        public int AB { get { return ab; } set { ab = value; } }



        public Player(string n,string j)
        {
            name = n;
            lvl = 1;
            wpn = new AllWeapons().wpnRnd();
            statsCalculation(j);
        }


        //Unused class in this implementation, displays the total stats
        public void statsDisplay()
        {

            Console.WriteLine(Name + "'s stats: " + "\n" +
                "\tLevel " + Lvl + " " + Job + "\n" +
                "\tHP: " + Current_hp + "/" + Max_hp + "\n" +
                "\tAttack: " + Damage + "\n" +
                "\tArmor: " + Armor + "\n" +
                "\tConstitution: " + Constitution
                );
        }


        //Initializes the stats according to class
        public void statsCalculation (string j)
        {
            if (j != null || j.ToLower().Equals("warrior") || j.ToLower().Equals("rogue"))
                job = j;
            else
                job = "Beggar";
 

            switch (job.ToLower())
            {
                case "warrior":
                    constitution = 3; armor = 1; damage = 1 + wpn.damageBonus; 
                    break;
                case "rogue":
                    constitution = 1; armor = 0; damage = 3 + wpn.damageBonus; 
                    break;
                default:
                    constitution = 0; armor = 0; damage = 1 + wpn.damageBonus; 
                    break;
            }
            max_hp = 10 + (2 + constitution) * lvl;
            current_hp = max_hp;
        }


        //Lvl up growth according to character class
        public void levelUp ()
        {
            
            lvl++;
            switch (job.ToLower())
            {
                case "warrior":
                    ++constitution;
                    if (lvl % 3 == 0) ++damage;
                    if (lvl % 5 == 0) ++armor;
                    break;
                case "rogue":
                    ++damage;
                    if (lvl % 3 == 0) ++constitution;
                    break;
                default:
                    if (lvl % 3 == 0) { ++damage; ++armor; ++constitution; }
                    if (lvl % 5 == 0) { damage += 2; armor += 2;constitution += 2; }

                    break;
            }
            max_hp = 10 + (2 + constitution) * lvl;
        }

        //pAR= Player Attack Roll
        //Uses the same calculation as before, but a roll for the damage of the weapon is added.
        public void Attack(Villain badman)
        {
            Random rnd = new Random();
            int pAR = rnd.Next(1, 21);
            int wpnRoll = rnd.Next(wpn.wpnMinBaseDamage, wpn.wpnMaxBaseDamage);
            if ((pAR + AB) < (badman.villainBaseAC + badman.villainArmorAC))
            {
                Console.WriteLine("You roll " + (pAR + AB) +" against "
                    + badman.villainName + "'s armorclass of " + (badman.villainBaseAC + badman.villainArmorAC) + ". You miss.");
            }
            else
            {
                Console.WriteLine("You roll " + (pAR + AB) + " against "
                    + badman.villainName + "'s armorclass of " + (badman.villainBaseAC + badman.villainArmorAC) +
                    ". You hit " + badman.villainName + " for " + (Damage + wpnRoll) + " damage.");
                badman.currentHP = badman.villainHp - (Damage+wpnRoll);
                Console.WriteLine(badman.villainName + " has " + badman.currentHP + " HP left.");
            }


            Console.ReadLine();
            
        }


        //Defends, modifying the BaseAC for the incoming attack
        public void Defend()
        {
            Console.WriteLine(Name + " defends.");
            //Modifies the armor values for the turn
            Def = true;
            BaseAC += 10;
        }


        //Heals a percentage of max health
        public void Rest()
        {
            Console.WriteLine(Name + "treats wounds.");
            int aux;
            aux = (int)(Current_hp * 1.2);
            if (aux > Max_hp)
            {
                Current_hp = Max_hp;
            }
            else
            {
                Current_hp = aux;
            }
        }


        //Heals a percetage of max health after each combat
        public void postCombatHealing()
        {
            int postCH = (int)(0.25 * Max_hp);
            int aux;
            aux = Current_hp + postCH;
            if (aux > Max_hp)
            {
                Current_hp = Max_hp;
            }

            else
            {
                Current_hp = aux;
            }
            Console.WriteLine("Post combat healing: \n");
            Console.WriteLine("You heal " + postCH + " HP.\n");
        }

    }
}
