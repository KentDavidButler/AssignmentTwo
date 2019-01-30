using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangManStarterKit
{
    class VowelSmrtPlayer : Player
    {
        public override char Guess()
        {

            return GetChar(guessCount);
        }

        private char GetChar(int i)
        {
            char[] charArray = {'a', 'e', 'i', 'o', 'u', 't', 'n', 's',
                'r', 'h', 'l', 'd', 'c', 'm', 'f', 'p', 'g', 'w', 'y',
                'b', 'v', 'k', 'x', 'j', 'q', 'z' };
            guessCount++;
            return charArray[i];
        }
    }
}
