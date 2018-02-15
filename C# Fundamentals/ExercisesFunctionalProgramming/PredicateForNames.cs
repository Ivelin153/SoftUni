namespace PredicateForNames
{
    using System;

    class UsingPredicates
    {
        static void Main()
        {
            var nameLength = int.Parse(Console.ReadLine());

            var names = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.None);

            Predicate<string> predicate = n => n.Length <= nameLength;

            foreach (var name in names)
            {
                if (predicate(name))
                {
                    Console.WriteLine(name);
                }
            }
        }
    }
}
