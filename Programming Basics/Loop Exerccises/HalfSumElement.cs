using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalfSumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var sum = 0;
            var biggestNumber = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                var number = int.Parse(Console.ReadLine());
                if (number > biggestNumber)
                {
                    biggestNumber = number;
                }
                sum += number;
                Console.WriteLine(sum - biggestNumber);
            }
            if (sum - biggestNumber == biggestNumber)
            {
                Console.WriteLine("Yes");
                Console.WriteLine("Sum = {0}", sum - biggestNumber);
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine("Diff = {0}",
                    Math.Abs((sum - biggestNumber) - biggestNumber));
            }

        }
    }
}
