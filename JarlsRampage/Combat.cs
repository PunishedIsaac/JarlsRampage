using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JarlsRampage;

namespace JarlsRampage
{
    class Combat
    {
        Player p1;
        Villain enemy;
        string option;

        public Combat(Player p,Villain cpu)
        {
            p1 = p;
            enemy = cpu;
        }

        //Manages the flow of the combat, return a boolean that depends on winning or losing the battle
        public Boolean Battle()
        {
            
            while (p1.Current_hp > 0)
            {

                //Player turn
                Console.WriteLine(
                "HP: " + p1.Current_hp + "/" + p1.Max_hp + "\n" +
                "\t1. Attack (A)\n" +
                "\t2. Defend (D)\n" +
                "\t3. Rest   (H)\n");
                
               
                option = Console.ReadLine();
                if (option.Equals("")) option = "defend";
                //Methods explained on Player Class
                switch (option[0].ToString().ToLower())
                {
                    case "a":
                        
                        p1.Attack(enemy);
                        break;
                    case "d":

                        p1.Defend();
                        break;
                    case "h":
                        
                        p1.Rest();

                        break;
                    default:
                        p1.Defend();
                        break;
                }


                //Result of winning
                if (enemy.currentHP < 1)
                {
                    return true;
                    
                }

                //Enemy turn
                enemy.VillainTurn(p1);
                //Cibran: after the turn ends, we shouldn't have the status defending active.
                if (p1.Def)
                {
                    p1.BaseAC -= 10;
                    p1.Def = false;
                }


            }
                //Result of dying
                return false;


    
        }





       
    
    }
}
