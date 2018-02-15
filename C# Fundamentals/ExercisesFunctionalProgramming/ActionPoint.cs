namespace ActionPoint
{
    using System;

    class UsingActions
    {
        static void Main()
        {
            Action<string> namePrinter = n => Console.WriteLine($"Sir {n}");

            var input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.None);

            foreach (var name in input)
            {
                namePrinter(name);
            }
        }
    }
}
