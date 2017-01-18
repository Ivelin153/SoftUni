using System;

namespace Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            double p1 = 0.00;
            double p2 = 0.00;
            double p3 = 0.00;
            double p4 = 0.00;
            double p5 = 0.00;
            var currentNumber = 0;

            for (int i = 1; i <= n; i++)
            {
                currentNumber = int.Parse(Console.ReadLine());
                if (currentNumber < 200)
                {
                    p1 += 1;
                }
                else if (currentNumber >= 200 && currentNumber <= 399)
                {
                    p2 += 1;
                }
                else if (currentNumber >= 400 && currentNumber <= 599)
                {
                    p3 += 1;
                }
                else if (currentNumber >= 600 && currentNumber <= 799)
                {
                    p4 += 1;
                }
                else if (currentNumber >= 800)
                {
                    p5 += 1;
                }
            }
            Console.WriteLine("{0:f2}%", (p1 / n) * 100);
            Console.WriteLine("{0:f2}%", (p2 / n) * 100);
            Console.WriteLine("{0:f2}%", (p3 / n) * 100);
            Console.WriteLine("{0:f2}%", (p4 / n) * 100);
            Console.WriteLine("{0:f2}%", (p5 / n) * 100);
        }
    }
}