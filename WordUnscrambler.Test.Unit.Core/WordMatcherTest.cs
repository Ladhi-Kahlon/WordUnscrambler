using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordUnscrambler.App_Code;

namespace WordUnscrambler.Test.Unit.Core
{
    [TestClass]
    public class WordMatcherTest
    {
        private  readonly WordMatcher _wm = new WordMatcher();

        [TestMethod]
        public void MatchScrambleWordToWordList()
        {
            string[] scrambledWords = { "Test", "Two", "More" };
            string[] wordList = { "One", "Test", "Yes", "Their" };
            
            var matchWord = _wm.Match(scrambledWords, wordList);

            Assert.IsTrue(matchWord.Count == 1);
            Assert.IsTrue(matchWord[0].ScrambledWord.Equals("Test"));
            Assert.IsTrue(matchWord[0].Word.Equals("Test"));
        }

        [TestMethod]
        public void MatchScrambleWordsToWordList()
        {
            string[] scrambledWords = { "Match", "Yes", "No", "Test" };
            string[] wordList = { "One", "Test", "Yes", "Their" };
            

            var matchWords = _wm.Match(scrambledWords, wordList);

            Assert.IsTrue(matchWords.Count == 2);
            Assert.IsTrue(matchWords[0].ScrambledWord.Equals("Yes"));
            Assert.IsTrue(matchWords[0].Word.Equals("Yes"));
            Assert.IsTrue(matchWords[1].ScrambledWord.Equals("Test"));
            Assert.IsTrue(matchWords[1].Word.Equals("Test"));
        }
    }
}
