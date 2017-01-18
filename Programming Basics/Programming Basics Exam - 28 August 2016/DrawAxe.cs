using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Axe
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var mid = n - 1;
            var left = 3 * n;
            var right = n - 1;
            var width = 5 * n;

            Console.WriteLine(new String('-', left) + "**" + new String('-', 2 * n - 2));

            for (int i = 1; i <= n - 1; i++)
            {
                Console.WriteLine(new String('-', left) + "*" + new String('-', i) + "*" + new String('-', 2 * n - 2 - i));
            }
            for (int j = 1; j <= n / 2; j++)
            {
                Console.WriteLine(new String('*', left) + "*" + new String('-', mid) + "*" + new String('-', right));
            }

            for (int l = 1; l <= n / 2 - 1; l++)
            {
                Console.WriteLine(new String('-', left) + "*" + new String('-', mid) + "*" + new String('-', right));
                mid += 2;
                left--;
                right--;
            }
            Console.WriteLine("{0}*{1}*{2}",
                new string('-', left),
                new string('*', mid),
                new string('-', right));
        }
    }
}
