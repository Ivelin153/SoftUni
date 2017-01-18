using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristmasHat
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var dots = 2 * n - 1;
            var dashes = 0;

            Console.WriteLine(new String('.', 2 * n - 1) + "/|\\" + new String('.', 2 * n - 1));
            Console.WriteLine(new String('.', 2 * n - 1) + "\\|/" + new String('.', 2 * n - 1));

            for (int i = 0; i < 2 * n; i++)
            {
                Console.WriteLine(new String('.', dots) + "*" + new string('-', dashes) + "*" + new string('-', dashes) + "*" + new String('.', dots));
                dots--;
                dashes++;
            }
            Console.WriteLine(new String('*', 4 * n + 1));
            for (int i = 0; i < 2 * n; i++)
            {
                Console.Write('*');
                Console.Write('.');
            }
            Console.Write("*");
            Console.WriteLine();
            Console.WriteLine(new String('*', 4 * n + 1));
        }
    }
}
