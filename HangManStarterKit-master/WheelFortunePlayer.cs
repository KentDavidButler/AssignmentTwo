using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangManStarterKit
{
    class WheelFortunePlayer : Player
    {
        public override char Guess()
        {

            return GetChar(guessCount);
        }

        private char GetChar(int i)
        {
            char[] charArray = {'e', 'a', 't', 'i', 'r', 'o', 'n', 's',
                'l', 'h', 'c', 'd', 'g', 'u', 'p', 'm', 'f', 'b', 'y',
                'w', 'k', 'v', 'j', 'x', 'z', 'q' };
            guessCount++;
            return charArray[i];
        }
    }
}
