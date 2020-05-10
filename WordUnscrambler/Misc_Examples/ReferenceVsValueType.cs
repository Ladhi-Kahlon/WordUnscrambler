using System;

namespace WordUnscrambler.Misc_Examples
{
    class ReferenceVsValueType
    {
        public void UseCase()
        {
            int v = 55;
            ValueTypeCheck(v);
            
            // Using ref and out on value types (good to know, not a good practice)

            //reference must be initialize 
            int r = 0;
            UsingRef(ref r);

            // must be assigned before leave the control
            // ReSharper disable once InlineOutVariableDeclaration
            // ReSharper disable once RedundantAssignment
            int o = 9;
            UsingOut(out o);

            Console.WriteLine($"Value Type (Original: 55): {v}");
            Console.WriteLine($"Using Ref (Original: 0): {r}");
            Console.WriteLine($"Using Out  (Original: 9): {o}");
        }

        // ReSharper disable once UnusedParameter.Local
        // ReSharper disable once RedundantAssignment
        private void ValueTypeCheck(int i)
        {
            // ReSharper disable once RedundantAssignment
            i = 5000;
        }

        // ReSharper disable once RedundantAssignment
        private void UsingRef(ref int i)
        {
            i = 9;
        }

        private void UsingOut(out int i)
        {
            //must be assigned before leave the control
            i = 100;
        }
    }
}