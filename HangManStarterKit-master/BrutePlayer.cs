using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangManStarterKit
{
    class BrutePlayer : Player
    {
        public override char Guess()
        {
            
            return GetChar(guessCount);
        }

        private char GetChar(int i)
        {
            char[] charArray = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h',
                'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's',
                't', 'u', 'v', 'w', 'x', 'y', 'z' };
            guessCount++;

            return charArray[i];
        }
    }
}
