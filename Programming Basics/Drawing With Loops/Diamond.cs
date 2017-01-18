using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamond
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var leftRight = (n - 1) / 2;
            var mid = n - 2 * leftRight - 2;

            Console.WriteLine(new String('-', leftRight) + new string('*', n - 2 * leftRight) + new String('-', leftRight));

            //toMiddleRow
            if (n % 2 != 0)
            {
                for (int i = 1; i <= n / 2; i++)
                {
                    mid += 2;
                    leftRight--;
                    Console.WriteLine(new String('-', leftRight) + '*' + new string('-', mid) + "*" + new String('-', leftRight));
                }
            }
            else
            {
                for (int i = 1; i <= n / 2 - 1; i++)
                {
                    mid += 2;
                    leftRight--;
                    Console.WriteLine(new String('-', leftRight) + '*' + new string('-', mid) + "*" + new String('-', leftRight));
                }
            }

            if (n % 2 != 0)
            {
                for (int i = 1; i <= n / 2 - 1; i++)
                {
                    mid -= 2;
                    leftRight++;
                    Console.WriteLine(new String('-', leftRight) + '*' + new string('-', mid) + "*" + new String('-', leftRight));
                }

            }
            else
            {
                for (int i = 1; i < n / 2; i++)
                {
                    mid -= 2;
                    leftRight++;
                    Console.WriteLine(new String('-', leftRight) + '*' + new string('-', mid) + "*" + new String('-', leftRight));
                }
            }

            if (n % 2 != 0 && n != 1)
            {
                Console.WriteLine(new String('-', n / 2) + "*" + new String('-', n / 2));
            }
        }
    }
}
