using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var width = 2 * n - 1;
            var height = 2 * (n - 2) + 1;
            var leftRight = n - 1;

            for (int i = 1; i <= n - 2; i++)
            {
                if (i % 2 != 0)
                {
                    Console.WriteLine(new String('*', leftRight - 1) + '\\' + " /" + new String('*', leftRight - 1));
                }
                else
                {
                    Console.WriteLine(new String('-', leftRight - 1) + '\\' + " /" + new String('-', leftRight - 1));
                }
            }
            Console.WriteLine(new String(' ', leftRight) + "@" + new String(' ', leftRight));
            for (int i = 1; i <= n - 2; i++)
            {
                if (i % 2 != 0)
                {
                    Console.WriteLine(new String('*', leftRight - 1) + '/' + " \\" + new String('*', leftRight - 1));
                }
                else
                {
                    Console.WriteLine(new String('-', leftRight - 1) + '/' + " \\" + new String('-', leftRight - 1));
                }
            }
        }
    }
}
