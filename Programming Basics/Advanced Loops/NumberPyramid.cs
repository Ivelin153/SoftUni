using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberPyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var num = 1;

            for (int row = 0; row <= n; row++)
            {
                for (int col = 0; col <= row; col++)
                {

                    Console.Write(num);
                    Console.Write(" ");
                    num++;
                    if (num > n)
                        break;

                }
                Console.WriteLine();
                if (num > n)
                {
                    break;
                }
            }
        }
    }
}
