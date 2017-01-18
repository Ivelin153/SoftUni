using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var p1 = 0.00;
            var p2 = 0.00;
            var p3 = 0.00;
            var p4 = 0.00;
            var p5 = 0.00;
            for (int i = 0; i < n; i++)
            {
                var number = int.Parse(Console.ReadLine());

                if (number < 200)
                {
                    p1 += 1;
                }
                else if (number < 400)
                {
                    p2 += 1;
                }
                else if (number < 600)
                {
                    p3 += 1;
                }
                else if (number < 800)
                {
                    p4 += 1;
                }
                else
                {
                    p5 += 1;
                }
            }
            Console.WriteLine("{0:f2}%", p1 / n * 100);
            Console.WriteLine("{0:f2}%", p2 / n * 100);
            Console.WriteLine("{0:f2}%", p3 / n * 100);
            Console.WriteLine("{0:f2}%", p4 / n * 100);
            Console.WriteLine("{0:f2}%", p5 / n * 100);
        }
    }
}
