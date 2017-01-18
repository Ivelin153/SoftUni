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

            for (int i = 1; i <= n - 2; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(new String('-', n - 2) + "\\ /" + new String('-', n - 2));
                }
                else
                {
                    Console.WriteLine(new String('*', n - 2) + "\\ /" + new String('*', n - 2));
                }
            }
            Console.WriteLine(new String(' ', n - 1) + "@" + new String(' ', n - 1));
            for (int i = 1; i <= n - 2; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(new String('-', n - 2) + "/ \\" + new String('-', n - 2));
                }
                else
                {
                    Console.WriteLine(new String('*', n - 2) + "/ \\" + new String('*', n - 2));
                }
            }
        }
    }
}
