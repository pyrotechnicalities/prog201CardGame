using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CardGame
{
    internal class Credits
    {
        // Fisher-Yates Shuffle from https://www.dotnetperls.com/fisher-yates-shuffle
        // Assistance with Fisher-Yates shuffle from https://stackoverflow.com/questions/25943286/fisher-yates-shuffle-on-a-cards-list
        // Some assistance provided by Dominic F (Primarily with building Deck class)
        // Some assistance provided by Janell Baxter (Primarily with building SameOrDifferent class and some functionality in Game)
        // Some assistance with Highest Match provided by Mack Pearson-Muggli
        // All other code by Leo Richnofsky
        public void ShowCredits()
        {
            Clear();
            WriteLine("Fisher-Yates Shuffle from https://www.dotnetperls.com/fisher-yates-shuffle");
            WriteLine("Assistance with Fisher-Yates shuffle from https://stackoverflow.com/questions/25943286/fisher-yates-shuffle-on-a-cards-list");
            WriteLine("Some assistance provided by Dominic F (Primarily with building Deck class)");
            WriteLine("Some assistance provided by Janell Baxter (Primarily with building SameOrDifferent class and some functionality in Game)");
            WriteLine("Some assistance with Highest Match provided by Mack Pearson-Muggli");
            WriteLine("All other code by Leo Richnofsky");
            WriteLine("Thanks for playing! Press any key to exit.");
            ReadKey();
        }
    }
}
