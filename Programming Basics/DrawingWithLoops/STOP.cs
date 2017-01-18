using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stop
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var mid = 2 * n - 1;

            Console.WriteLine(new String('.', n + 1) + new String('_', 2 * n + 1) + new String('.', n + 1));
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(new String('.', n - i) + "//" + new String('_', mid) + "\\\\" + new String('.', n - i));
                mid += 2;
            }
            Console.WriteLine("//" + new String('_', 2 * n - 3) + "STOP!" + new String('_', 2 * n - 3) + "\\\\");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(new String('.', i) + "\\\\" + new String('_', mid) + "//" + new String('.', i));
                mid -= 2;
            }
        }
    }
}
