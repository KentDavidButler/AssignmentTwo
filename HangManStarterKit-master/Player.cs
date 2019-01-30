using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangManStarterKit
{
    abstract class Player
    {
        public int wordLenght = 0;
        public int guessCount = 0;
        public abstract char Guess();
    }
}
