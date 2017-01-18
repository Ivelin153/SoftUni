using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rocket
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var width = 3 * n;
            var dots = (width - 2) / 2;
            var spaces = 0;
            var lowerDots = n / 2;
            var lowerMid = 2 * n - 2;

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(new String('.', dots) + "/" + new string(' ', spaces) + "\\" + new String('.', dots));
                dots--;
                spaces += 2;
            }

            Console.WriteLine(new String('.', n / 2) + new string('*', n * 2) + new String('.', n / 2));

            for (int i = 0; i < 2 * n; i++)
            {
                Console.WriteLine(new String('.', n / 2) + "|" + new string('\\', 2 * n - 2) + "|" + new String('.', n / 2));
            }

            for (int i = 0; i < n / 2; i++)
            {
                Console.WriteLine(new String('.', lowerDots) + "/" + new String('*', lowerMid) + "\\" + new String('.',lowerDots));
                lowerDots--;
                lowerMid += 2;
            }
        }
    }
}
