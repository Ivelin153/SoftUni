using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fox
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var width = 2 * n + 3;
            var mid = 2 * n - 1;
            var left = n / 2;
            var center = n;
            var middleRows = (2 * n) - 2 * n;
            var bottomMid = 2 * n - 1;

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(new String('*', i) + "\\" + new String('-', mid) + "/" + new String('*', i));
                mid -= 2;
            }
            for (int p = 1; p <= n / 3; p++)
            {
                Console.WriteLine("|" + new String('*', left) + "\\" + new String('*', center) + "/" + new String('*', left) + "|");
                center -= 2;
                left++;
            }

            for (int j = 1; j <= n; j++)
            {
                Console.WriteLine(new String('-', j) + "\\" + new String('*', bottomMid) + "/" + new String('-', j));
                bottomMid -= 2;
            }
        }
    }
}
