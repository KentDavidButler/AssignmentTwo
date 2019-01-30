/*
 * This class tries to make educated guesses on the letters in the word by
 * importing the list of words of the same lenght and then finding the frequency
 * of letters in each position.
 * 
 * This player child class is currently not working
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangManStarterKit
{
    class EducatedPlayer : Player
    {
        public int wordLength = 0;
        private int tries = 0;
        public override char Guess()
        {
            return GetCharacterFrequency();
        }

        private char GetCharacterFrequency()
        {
            var characterCount = new Dictionary<char, int>();
            foreach (var c in GetWordsFromFile())
            {
                if(guessCount > (wordLenght-1))
                {
                    guessCount = 0; //make sure we reset once we traverse the word
                    tries++;
                    Console.WriteLine($"GuessCount is {guessCount} and tries is {tries} .");
                }
                string tempStr = c.Substring(guessCount, 1);
                char temp = Char.Parse(tempStr);
                if (characterCount.ContainsKey(temp))
                {
                    characterCount[temp]++;
                }
                else
                {
                    characterCount[temp] = 1;
                }
            }

            guessCount++;
            return characterCount.FirstOrDefault(x => x.Value == (characterCount.Values.Max()) - tries).Key;
        }

        private List<string> GetWordsFromFile()
        {
            List<string> wordList = new List<string> { };
            string path = "..\\words.txt";
            foreach (string item in File.ReadAllLines(path))
            {
                if(item.Length == wordLenght)
                {
                    wordList.Add(item);
                }
            }
            return wordList;
        }
       
    }
}
