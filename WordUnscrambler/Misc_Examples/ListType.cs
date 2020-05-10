using System;
using System.Collections.Generic;

namespace WordUnscrambler.Misc_Examples
{
    internal static class ListType
    {
        internal static void ListTypeExample()
        {
            //int16: -32768 through 32767
            //int32: -2,147,483,648 through 2,147,483,647
            //int64: -9,223,372,036,854,775,808 through 9,223,372,036,854,775,807
            //uint:  0 through 4,294,967,295 numeric values

            var listArray = new List<uint>
            {
                10,
                7,
                1,
                5,
                2,
                0
            };
            listArray.Sort();
            listArray.Insert(0, 0);


            foreach (var list in listArray)
            {
                Console.WriteLine("Array List: " + list);
            }
        }


    }
}