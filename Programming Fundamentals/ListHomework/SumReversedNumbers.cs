using System;
using System.Collections.Generic;
using System.Linq;

namespace SumReversedNumbers
{
    public class Program
    {
        static void Main()
        {
            var input = Console.ReadLine()
                .Split(' ')
                .ToList();

            ReversedNumbers(input);
        }

        public static void ReversedNumbers(List<string> numbers)
        {
            string reversed = string.Empty;
            var sum = 0;
            foreach (var number in numbers)
            {
                foreach (char digit in number)
                {
                    reversed = digit + reversed;

                }

                sum += int.Parse(reversed);
                reversed = string.Empty;
            }
            Console.WriteLine(sum);

        }
    }
}
