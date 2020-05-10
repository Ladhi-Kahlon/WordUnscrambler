using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using WordUnscrambler.App_Code;

namespace WordUnscrambler
{
    public static class Program
    {
        private static readonly FileReader FileReader = new FileReader();
        private static readonly WordMatcher WordMatcher = new WordMatcher();
        private const string WordListFileName = Constant.WordFileName;

        private static void Main()
        {
            try
            {
                Console.WriteLine(Constant.AppWelcomeMsg);
                do
                {
                    string input;
                    do
                    {
                        Console.Write(Constant.AppUnscramblerOptions);
                        input = Console.ReadLine() ?? string.Empty;

                        if (string.Equals(input, Constant.FileInputIndicator, StringComparison.OrdinalIgnoreCase)
                            || string.Equals(input, Constant.ManualInputIndicator, StringComparison.OrdinalIgnoreCase))
                            break;

                        Console.WriteLine(Constant.AppUnscramblerOptionInvalid);
                    } while (true);


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
                    }

                    Console.Write(Constant.OptionToExitOrContinue);
                    if (!string.Equals(Console.ReadLine(), Constant.ExitAppIndicator, StringComparison.OrdinalIgnoreCase)) continue;

                    Console.WriteLine(Constant.ExistingApplication);
                    break;

                } while (true);
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
                throw new Exception(e.Message);
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
                throw new Exception(e.Message);
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
                throw new Exception(ex.Message);
            }
        }
    }
}
