namespace ListOfPredicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var range = int.Parse(Console.ReadLine());

            var sequence = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.None)
                .Select(int.Parse)
                .Distinct()
                .ToArray();

            Func<int, bool>[] predicates = sequence
                 .Select(div => (Func<int, bool>)(n => n % div == 0))
                 .ToArray();

            var list = new List<int>();

            for (int number = 1; number <= range; number++)
            {
                bool isDivisable = true;

                foreach (var predicate in predicates)
                {
                    if (!predicate(number))
                    {
                        isDivisable = false;
                        break;
                    }
                }

                if (isDivisable)
                {
                    list.Add(number);
                }
            }
            Console.WriteLine(string.Join(" ", list));
        }
    }
}
