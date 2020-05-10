using System;

namespace WordUnscrambler.Misc_Examples
{
    public static class NullVsNullCoalescing
    {
        public static void TestNullUseCase()
        {
            Person person = null; //new Person("Greg", "Smith");
            // ReSharper disable once ConstantNullCoalescingCondition
            Person checkNull = person ?? new Person("Default", "Key");

            Console.WriteLine(checkNull.FirstName);
            Console.WriteLine(checkNull.LastName);
        }
    }
}