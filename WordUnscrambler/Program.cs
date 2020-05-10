using System;
using System.Linq;
using WordUnscrambler.App_Code;

namespace WordUnscrambler
{
    public static class Program
    {
        private static readonly FileReader FileReader = new FileReader();
        private static readonly WordMatcher WordMatcher = new WordMatcher();
        private const string WordListFileName = Constant.WordFileName;

        public static void Main()
        {
            try
            {
                bool continueApp;

                Console.WriteLine(Constant.AppWelcomeMsg);
                do
                {
                    Console.Write(Constant.AppUnscramblerOptions);
                    var input = Console.ReadLine() ?? string.Empty;

                    // Main execution for File input or Manual entry
                    switch (input.ToUpper())
                    {
                        case Constant.FileInputIndicator:
                            Console.Write(Constant.UsingFileToUnscrambleWord);
                            ExecuteScramblerInFileScenario();
                            break;
                        case Constant.ManualInputIndicator:
                            Console.WriteLine(Constant.UsingManualInputToUnscrambleWord);
                            ExecuteScramblerManualEntryScenario();
                            break;
                        default:
                            Console.WriteLine(Constant.AppUnscramblerOptionInvalid);
                            break;
                    }

                    string continueDecision;
                    do
                    {
                        Console.Write(Constant.OptionToExitOrContinue);
                        continueDecision = Console.ReadLine() ?? string.Empty;

                    } while (!string.Equals(continueDecision, Constant.ContinueDecisionYes, StringComparison.OrdinalIgnoreCase)
                             && !string.Equals(continueDecision, Constant.ContinueDecisionNo, StringComparison.OrdinalIgnoreCase));

                    continueApp = continueDecision.Equals(Constant.ContinueDecisionYes, StringComparison.OrdinalIgnoreCase);

                } while (continueApp);
                Console.WriteLine(Constant.ExistingApplication);
            }
            catch (Exception e)
            {
                Console.WriteLine(Constant.ApplicationErrorMsg + e.Message);
            }
        }

        private static void ExecuteScramblerManualEntryScenario()
        {
            try
            {
                var input = Console.ReadLine() ?? string.Empty;

                // Removed whitespace between words if any
                var inputString = string.Concat(input.Where(c => !char.IsWhiteSpace(c)));

                var scrambledWords = inputString.Split(',');

                DisplayMatchScrambledWords(scrambledWords);
            }
            catch (Exception e)
            {
                Console.WriteLine(Constant.AppScrambledWordsLoadError + e.Message);
            }
        }

        private static void ExecuteScramblerInFileScenario()
        {
            try
            {
                var fileName = Console.ReadLine() ?? string.Empty;
                var scrambledWords = FileReader.Read(fileName);

                DisplayMatchScrambledWords(scrambledWords);
            }
            catch (Exception e)
            {
                Console.WriteLine(Constant.AppScrambledWordsLoadError + e.Message);
            }
        }

        private static void DisplayMatchScrambledWords(string[] scrambledWords)
        {
            try
            {
                // Get List of words to run unscrambler words against
                var wordList = FileReader.Read(WordListFileName);

                var matchWords = WordMatcher.Match(scrambledWords, wordList);

                if (matchWords.Any())
                {
                    foreach (var matchword in matchWords)
                    {
                        Console.WriteLine($"Match found for {matchword.ScrambledWord}: {matchword.Word}");
                    }
                }
                else
                {
                    Console.WriteLine(Constant.MatchNotFound);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(Constant.AppScrambledWordsLoadError + ex.Message);
            }
        }
    }
}
