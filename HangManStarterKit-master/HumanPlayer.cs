using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangManStarterKit
{
    class HumanPlayer : Player
    {
        public override char Guess()
        {
            while (true)
            {
                if(char.TryParse(Console.ReadLine(),out char guess))
                {
                    if(guess >= 'a' && guess <= 'z')
                    {
                        guess = Char.ToLower(guess);
                        return guess;
                    }
                }

                Console.WriteLine("Sorry, that is not a letter.");
            }
        }

    }
}
