namespace WordUnscrambler
{
    public static class Constant
    {
        public const string WordFileName = "AppWordList.txt";

        public const string AppWelcomeMsg = "Welcome to Word-Unscrambler App:";
        public const string AppUnscramblerOptions = "Enter \"F\" for file name or \"M\" for manual input: ";
        public const string AppUnscramblerOptionInvalid = "Wrong Input.";

        public const string UsingFileToUnscrambleWord = "Enter File Name: ";
        public const string UsingManualInputToUnscrambleWord = "Enter \",\" comma separated words list manually: ";

        public const string FileInputIndicator = "F";
        public const string ManualInputIndicator = "M";
        public const string MatchNotFound = "No match found";
        public const string ContinueDecisionYes = "Y";
        public const string ContinueDecisionNo = "N";

        public const string OptionToExitOrContinue = "Would you like to continue? Y/N: ";

        public const string ExistingApplication = "Existing application.";

        public const string ApplicationErrorMsg = "Program is being terminated due to error: ";
        public const string AppScrambledWordsLoadError = "Unable to load scrambled word due to an error. ";
    }
}
