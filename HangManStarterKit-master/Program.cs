using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangManStarterKit
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Welcome to the Hangman Game");
            Console.WriteLine("Select an option: ");
            do
            {
                int input = UserActions();
                if(input != 9)
                {
                    Player[] p = { new HumanPlayer(), new BrutePlayer(),
                        new RandoPlayer(), new VowelSmrtPlayer(),
                        new WheelFortunePlayer(), new EducatedPlayer() };
                    HangmanGame hg = new HangmanGame(p[input]);
                }
                else
                {
                    GetAverageGuessesOfPlayers();
                }

                Console.Write("Play again ");
            } while (YesOrNo());
            Console.WriteLine("Good Bye.");
        }

        private static void GetAverageGuessesOfPlayers()
        {
            Player[] p = { new BrutePlayer(), new RandoPlayer(),
                new VowelSmrtPlayer(), new WheelFortunePlayer() };

            int[] average = new int[p.Length];
            for (int i = 0; i < p.Length; i++)
            {
                int index = 0;
                int[] tries = new int[10];
                for (int j = 0; j < 9; j++)
                {
                    HangmanGame hg = new HangmanGame(p[i]);
                    tries[index] = hg.tries;
                    index++;
                    if (i != 1)
                    {
                        p[i].guessCount = 0;
                    }
                }
                average[i] = tries.Sum();
            }
            Console.WriteLine($"The Bruteforce Player average is {(average[0]/average.Length)}.");
            Console.WriteLine($"The Random Player average is {(average[1] / average.Length)}.");
            Console.WriteLine($"The Efficent Bruteforce Player average is {(average[2] / average.Length)}.");
            Console.WriteLine($"The Wheel of Fortune Player average is {(average[3] / average.Length)}.");
            Console.WriteLine($"The Educated average is not working.");

        }

        private static bool YesOrNo()
        {
            string input;
            while (true)
            {
                Console.Write("(y/n):");
                input = Console.ReadLine().ToLower();
                if (String.Equals("n", input))
                {
                    return false;
                }
                else if (String.Equals("y", input))
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("That is an invalid entry!");
                    continue;
                }
            }
        }

        public static int UserActions()
        {
            Console.WriteLine("Press 1 to play.");
            Console.WriteLine("Press 2 to let a Bruteforce Player play.");
            Console.WriteLine("Press 3 to let a Random Player play.");
            Console.WriteLine("Press 4 to let an Efficent Bruteforce Player play.");
            Console.WriteLine("Press 5 to let a Wheel of Fortune Player play.");
            Console.WriteLine("Press 6 to let an Educated Player play. Not Working");
            Console.WriteLine("Press 9 to let all AI players play 10 times to see their average efficency.");
            do
            {
                var input = Console.ReadKey();
                Console.WriteLine(" ");
                if (input.Key == ConsoleKey.D1)
                {
                    Console.WriteLine("You chose to play!");
                    return 0;
                }
                else if (input.Key == ConsoleKey.D2)
                {
                    Console.WriteLine("You chose the Bruteforce Player!");
                    return 1;
                }
                else if (input.Key == ConsoleKey.D3)
                {
                    Console.WriteLine("You chose the Random Player!");
                    return 2;
                }
                else if (input.Key == ConsoleKey.D4)
                {
                    Console.WriteLine("You chose The Smart Vowel Player!");
                    return 3;
                }

                else if (input.Key == ConsoleKey.D5)
                {
                    Console.WriteLine("You chose The Wheel of Fortune Player!");
                    return 4;
                }
                else if (input.Key == ConsoleKey.D6)
                {
                    Console.WriteLine("You chose The Educated Player!");
                    return 5;
                }
                else if (input.Key == ConsoleKey.D9)
                {
                    Console.WriteLine("You chose to check all players efficency!");
                    return 9;
                }
                else
                {
                    Console.WriteLine("That is not an option.");
                    Console.WriteLine("Press 1 through 5 to choose a player.");
                }
            } while (true);

        }
    }

}
