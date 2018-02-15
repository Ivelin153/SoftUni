namespace CustomComparator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class CustComparartor
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.None)
                .Select(int.Parse)
                .ToArray();

            Func<int[], int[]> sortedEvens = array =>
            {
                var sortedEvensArray = array
                .Where(n => n % 2 == 0)
                .OrderBy(n => n)
                .ToArray();

                return sortedEvensArray;
            };

            Func<int[], int[]> sortedOdds = array =>
            {
                var sortedOddsArray = array
                .Where(n => n % 2 != 0)
                .OrderBy(n => n)
                .ToArray();

                return sortedOddsArray;
            };

            var filteredNumbers = new List<int>();

            filteredNumbers.AddRange(sortedEvens(numbers));
            filteredNumbers.AddRange(sortedOdds(numbers));

            Console.WriteLine(string.Join(" ", filteredNumbers));
        }
    }
}
