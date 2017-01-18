using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddEvenSUM
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var evenSum = 0.00;
            var oddSum = 0.00;

            for (int i = 1; i <= n; i++)
            {
                var number = int.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    evenSum += number;
                }
                else
                {
                    oddSum += number;
                }
            }
            if (evenSum == oddSum)
            {
                Console.WriteLine("Yes, sum = {0}", evenSum);
            }
            else
            {
                Console.WriteLine("No, diff = {0}",
                    Math.Abs(evenSum-oddSum));
            }
        }
    }
}
