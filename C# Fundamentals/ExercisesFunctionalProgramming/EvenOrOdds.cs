namespace FindEvenOrOdds
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class EvenOrOdds
    {
        static void Main()
        {
            var range = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var list = new List<int>();
            var oddOrEven = Console.ReadLine();

            Predicate<int> predicate;
            {
                switch (oddOrEven)
                {
                    case "odd":
                        predicate = n => n % 2 != 0;
                        break;

                    case "even":
                        predicate = n => n % 2 == 0;
                        break;

                    default:
                        predicate = null;
                        break;
                }
            };

            for (int numb = range[0]; numb <= range[1]; numb++)
            {
                if (predicate(numb))
                {
                    list.Add(numb);
                }
            }
            Console.WriteLine(string.Join(" ", list));
        }
    }
}
