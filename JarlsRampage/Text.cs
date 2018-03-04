using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JarlsRampage
{
    class Text
    {

        private int stage { get; set; }

        public int Stage { get { return stage; } set { stage = value; } }

        public Text()
        {
            Stage = 1;
        }


        //Introduction text
        public void Intro(Player p1)
        {
            Console.WriteLine("\nYou, " + p1.Name + ", are a mercenary warrior from the Kingdom of Saaria.");
            Console.WriteLine("The king Jan II has hired you to assasinate a rogue Jarl.");
            Console.WriteLine("In order to get to the Jarl, you must first dispatch of his assortment of bodyguards.");
            Console.WriteLine("You start with the first bodyguard, who you challenge to combat.\n");
            Console.ReadLine();

        }


        //PostCombat text, has a variable to automatically move the stage
        public void PostCombat()
        {
            if (stage == 1)
            {
                Console.WriteLine("You have defeated the first bodyguard.");
                Console.WriteLine("You decide to have a lunch before the next bodyguard.");
                Console.WriteLine("You eat some swede soup. The second bodyguard interrupts your lunch.");
                Console.WriteLine("What a douchebag.");
            };

            if (stage == 2)
            {
                Console.WriteLine("You have defeated the second bodyguard.");
                Console.WriteLine("The swede soup has spilled all over the floor.");
                Console.WriteLine("You decide to eat salmon instead.");
                Console.WriteLine("However, your lunch was once again interrupted by a bodyguard.");
            };
            if (stage == 3)
            {
                Console.WriteLine("You have defeated the third bodyguard.");
                Console.WriteLine("The salmon has fallen to the ground, and is all dirty.");
                Console.WriteLine("By this point you've already lost your appetite.");
                Console.WriteLine("You decide to move on towards the Jarl's domain.");
                Console.WriteLine("While on the road, a fourth bodyguard attacks you.");
            };
            if (stage == 4)
            {
                Console.WriteLine("You have defeated the fourth bodyguard.");
                Console.WriteLine("When continuing the trail, you notice a letter given to the bodyguard.");
                Console.WriteLine("Unfortunetaly, you're illiterate, so you ignore the letter.");
                Console.WriteLine("You get attacked by another bodyguard.");
            };
            if (stage == 5)
            {
                Console.WriteLine("You have defeated the fifth bodyguard.");
                Console.WriteLine("Before dying, the bodyguard mumbles something about the Jarl and names.");
                Console.WriteLine("You are not so interested. So you move on.");
                Console.WriteLine("You arrive at Jarl's personal domain.");
                Console.WriteLine("You are greeted by an attacking bodyguard. How nice!");
            };
            if (stage == 6)
            {
                Console.WriteLine("You have defeated the sixth bodyguard.");
                Console.WriteLine("You see some scared villagers hiding from you.");
                Console.WriteLine("You tell them you're here to bring peace.");
                Console.WriteLine("While trying to explain your intentions, a bodyguard attacks you from behind.");
            };
            if (stage == 7)
            {
                Console.WriteLine("You have defeated the seventh bodyguard.");
                Console.WriteLine("You ponder on several things.");
                Console.WriteLine("Why does the Jarl hire bodyguards from very different backgrounds?");
                Console.WriteLine("Why has the Jarl betrayed the king?");
                Console.WriteLine("Where can I get some food around here?");
                Console.WriteLine("Then suddenly, you notice another bodyguard attacking you.");
            };
            if (stage == 8)
            {
                Console.WriteLine("You have defeated the eighth bodyguard.");
                Console.WriteLine("You approach the Jarl's palace.");
                Console.WriteLine("A bodyguard is stationed near the entrance, guarding it.");
                Console.WriteLine("You decide to strike them before they strike you.");
            };
            if (stage == 9)
            {
                Console.WriteLine("You have defeated the final bodyguard.");
                Console.WriteLine("You break the Jarl's door, and shout obscenities at him.");
                Console.WriteLine("The Jarl seems confused, but defends himself.");
                Console.WriteLine("You begin the final battle.");
            };

            Stage++;
        }
    }
}
