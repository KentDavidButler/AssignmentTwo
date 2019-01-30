using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangManStarterKit
{
    class RandoPlayer : Player
    {
        Random ranChar = new Random();
        public override char Guess()
        {
            return GetChar();
        }

        private char GetChar()
        {
            int i = ranChar.Next(0, 25);
            char[] charArray = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h',
                'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's',
                't', 'u', 'v', 'w', 'x', 'y', 'z' };
            return charArray[i];
        }
    }
}
