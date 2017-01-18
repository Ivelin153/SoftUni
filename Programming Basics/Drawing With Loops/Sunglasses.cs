using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunglasses
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            //first row
            Console.WriteLine(new String('*', 2 * n) + new String(' ',n) + new String('*', 2 * n));

            //middle rows
            for (int row = 0; row < n - 2; row++)
            {
                if (row == (n - 1) / 2 - 1)
                {
                    Console.WriteLine('*' + new String('/', 2 * n - 2) + '*' + new String('|', n) + '*' + new String('/', 2 * n - 2) + '*');
                }
                else
                {
                    Console.WriteLine('*' + new String('/', 2 * n - 2) + '*' + new String(' ', n) + '*' + new String('/', 2 * n - 2) + '*');
                }
            }


            //last row
            Console.WriteLine(new String('*', 2 * n) + new String(' ',n) + new String('*', 2 * n));
        }
    }
}
