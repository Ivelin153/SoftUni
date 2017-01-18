using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddEvenPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var evenSum = 0.00;
            var evenMin = double.MaxValue;
            var evenMax = double.MinValue;
            var oddSum = 0.00;
            var oddMin = double.MaxValue;
            var oddMax = double.MinValue;
            for (int i = 1; i <= n; i++)
            {
                var number = double.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    evenSum += number;
                    if (number > evenMax)
                    {
                        evenMax = number;
                    }

                    if (number < evenMin)
                    {
                        evenMin = number;
                    }
                }
                else
                {
                    oddSum += number;
                    if (number > oddMax)
                    {
                        oddMax = number;
                    }
                    if (number < oddMin)
                    {
                        oddMin = number;
                    }
                }
            }
            Console.WriteLine("OddSum={0},", oddSum);
            if (oddMin == double.MaxValue)
            {
                Console.WriteLine("oddMin=No");
            }
            else
            {
                Console.WriteLine("OddMin={0},", oddMin);
            }
            if (oddMax == double.MinValue)
            {
                Console.WriteLine("OddMax=No");
            }
            else
            {
                Console.WriteLine("OddMax={0},", oddMax);
            }
            Console.WriteLine("EvenSum={0},", evenSum);
            if (evenMin == double.MaxValue)
            {
                Console.WriteLine("EvenMin=No");
            }
            else
            {
                Console.WriteLine("EvenMin={0},", evenMin);
            }
            if (evenMax == double.MinValue)
            {
                Console.WriteLine("EvenMax=No");
            }
            else
            {
                Console.WriteLine("EvenMax={0}", evenMax);
            }
        }
    }
}