using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangManStarterKit
{
    class HangmanGame
    {
        //word that we are trying to guess
        public string word;
        public int tries = 0;
        public List<char> guessedLetters = new List<char>();
        public List<char> foundLetters = new List<char>();
        Player guesser;

        public HangmanGame(Player guesser)
        {
            this.guesser = guesser;
            //found a text document online of words, use IO to pull a random word from text doc
            word = GetWordFromFile();
            if(guesser.GetType().ToString().Contains("EducatedPlayer"))
            {
                //we feed extra info into the Educated Player class
                //need to find a way to give this info to single class 
                //and not parent class. Educated Player class not working
                guesser.wordLenght= word.Length;
            }

            Setup();
        }

        private string GetWordFromFile()
        {
            string path = "..\\words.txt";
            var lines = File.ReadAllLines(path);
            var r = new Random();
            var randomLineNumber = r.Next(0, lines.Length - 1);
            string line = lines[randomLineNumber];
            return line;
        }

        public HangmanGame(Player guesser, string word)
        {
            this.guesser = guesser;
            this.word = word;
            Setup();
        }

        private void Setup()
        {
            for (int i = 0; i < word.Length; i++)
            {
                foundLetters.Add('_');
            }
            Run();
        }

        public void Run()
        {
            while (HasWon() == false)
            {
                Console.WriteLine();
                PrintProgress();
                Console.WriteLine("Please guess a letter");
                char c = guesser.Guess();
                
                PlayRound(c);
            }
            PrintProgress();
        }

        public bool HasWon()
        {
            for(int i = 0; i < word.Length; i++)
            {
                if(foundLetters[i] != word[i])
                {
                    return false;
                }
            }
            Console.WriteLine("You won! Good Job!");
            return true;
        }

        public void PlayRound(char guess)
        {
            tries++;
            if (guessedLetters.Contains(guess))
            {
                Console.WriteLine("You already guessed that!");
            }
            else if (word.Contains(guess))
            {
                Console.WriteLine("Found a letter!");
                int index = word.IndexOf(guess);
                foundLetters[index] = guess;
                while(word.Substring(index+1).Contains(guess))
                {
                    index = 1+ index + word.Substring(index + 1).IndexOf(guess);
                    foundLetters[index] = guess;
                }
                foundLetters[index] = guess;
                guessedLetters.Add(guess);
            }
            else
            {
                guessedLetters.Add(guess);
                Console.WriteLine("No Letter found...");
            }
            Console.ReadLine();
            Console.Clear();
             
        }

        public void PrintProgress()
        {
            foreach(char c in foundLetters)
            {
                Console.Write(c + " ");
            }
            Console.WriteLine();
            Console.WriteLine("You have guessed: {0} times", tries);
        }
    }
}
