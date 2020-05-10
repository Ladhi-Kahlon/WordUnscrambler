using System;
using System.Collections.Generic;
using WordUnscrambler.App_Data;

// ReSharper disable once CheckNamespace
namespace WordUnscrambler.App_Code
{
    internal class WordMatcher
    {
        public List<MatchedWord> Match(string[] scrambledWords, string[] wordList)
        {
            var matchWords = new List<MatchedWord>();

            // Find matching word within the list from scrambled words
            foreach (var scrambledWord in scrambledWords)
            {
                foreach (var word in wordList)
                {
                    if (scrambledWord.Equals(word, StringComparison.OrdinalIgnoreCase))
                    {
                        matchWords.Add(BuildMatchWord(scrambledWord, word));
                    }
                    else
                    {
                        var scrambledWordArray = scrambledWord.ToCharArray();
                        var wordArray = word.ToCharArray();

                        Array.Sort(scrambledWordArray);
                        Array.Sort(wordArray);

                        var sortedScrambledWord = new string(scrambledWordArray);
                        var sortedWord = new string(wordArray);

                        if (sortedScrambledWord.Equals(sortedWord, StringComparison.OrdinalIgnoreCase))
                        {
                            matchWords.Add(BuildMatchWord(scrambledWord, word));
                        }

                    }
                }
            }

            return matchWords;
        }

        private MatchedWord BuildMatchWord(string scrambledWord, string word)
        {
            var matchedWord = new MatchedWord
            {
                ScrambledWord = scrambledWord, 
                Word = word
            };

            return matchedWord;
        }
    }
}