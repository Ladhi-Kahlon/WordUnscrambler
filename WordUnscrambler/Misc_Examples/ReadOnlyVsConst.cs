using System;

namespace WordUnscrambler.Misc_Examples
{
    class ReadOnlyVsConst
    {
        public const string ConstString = "Using const variable";

        public readonly string ReadOnlyString = "Using readonly string";

        public void UseCase()
        {
            Console.WriteLine(ConstString);
            Console.WriteLine(ReadOnlyString);
        }
    }
}