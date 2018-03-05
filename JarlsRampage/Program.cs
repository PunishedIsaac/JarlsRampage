using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using JarlsRampage;

namespace JarlsRampage
{
    class Program
    {

        //Things that can be improved:
        //  -Variable naming
        //  -Less use of private variables
        //  -Damage rolls and armor rolls




        static void Main(string[] args)
        {


            //First we start the soundtrack and declare variables
            int stage = 0;
            Boolean alive;
            Text gameText = new Text();
            SoundPlayer backtrack = new SoundPlayer();
            backtrack.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Tribal Ritual.wav";
            backtrack.PlayLooping();
            
            
            //ASCII game title
            
            
            
            
            
            Start:;
            //Naming the character
            Console.WriteLine("What is your name, adventurer?");
            string Name = Console.ReadLine();
            if (string.IsNullOrEmpty(Name))
            {
                Name = "Billy Bob Blank";
            }

            //Job class of the character
            Console.WriteLine("What's your profession?");
            string Profession = Console.ReadLine();
            if (string.IsNullOrEmpty(Profession)) Profession = "Beggar";


            //We create the Player with the information requested previously
            //The Weapon is randomized on the constructor
            Player p1 = new Player(Name, Profession);
            //Introduction text for the PC
            gameText.Intro(p1);

           

            //Stage starts
            Next:;
            //We select the Villain for the stage
            Villain badman = new AllVillains().nextVillain(stage);
            Console.WriteLine("You have encountered a wild " + badman.villainName);
            Console.ReadLine();



            //We create the combat for the stage
            Combat fight = new Combat(p1, badman);
            //A battle has two outcomes:
            //  -Victory: continue playing
            //  -Defeat: Game Over text
            alive = fight.Battle();
            if (!alive) {
                Console.WriteLine("\nYou have died. The Jarl no longer won't have his plans ruined.\n");
                Console.ReadKey();
                Console.WriteLine("Willing to play more?(Y/N)");
                string key = Console.ReadLine();
                if (key.StartsWith("y") | key.StartsWith("Y"))
                {
                    goto Start;
                }
                else
                {
                    goto End;
                }
            }



            //Actions taken before the next round:
            //  -Postcombat text
            //  -Lvl up
            //  -Postcombat healing
            //  -Change of stage
            if (stage < 9)
            {
                stage++;
                gameText.PostCombat();
                p1.levelUp();
                p1.postCombatHealing();
                goto Next;
            }





            //Ending text
            Console.ReadLine();
            if (String.Equals(p1.Name, "Timo"))
            {
                Console.WriteLine("After you have defeated the Jarl, you grab his necklace to bring to the king.");
                Console.WriteLine("After you present the necklace to the king, he shouts from his throne.");
                Console.WriteLine("'CONGRATULATIONS! YOU HAVE EARNED A COFFEE BREAK!'");
                Console.WriteLine("For this reason, the king lets you drink coffee publicly.");
            }
            else
            {
                Console.WriteLine("After you have defeated the Jarl, you grab his necklace to bring to the king.");
                Console.WriteLine("After you present the necklace to the king, he shouts from his throne.");
                Console.WriteLine("'THAT WAS THE WRONG JARL. THIS ONE WAS MY MOST LOYAL, YOU MONGREL!'");
                Console.WriteLine("For this treason, the king has you executed publicly.");

            }

            End:;

            //https://github.com/otuju004/
            //https://github.com/JustusJuutilainen/FS_Justuus
            //
        }
    }
}
