using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareFrame
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            //firstRow
            Console.Write("+");
            for (int i = 0; i < n - 2; i++)
            {
                Console.Write(" -");
            }
            Console.WriteLine(" +");

            //middleRows

            for (int i = 0; i < n - 2; i++)
            {
                Console.Write("|");
                for (int j = 0; j < n - 2; j++)
                {
                    Console.Write(" -");
                }
                Console.WriteLine(" |");

            }

            //lastRow
            Console.Write("+");
            for (int i = 0; i < n - 2; i++)
            {
                Console.Write(" -");
            }
            Console.WriteLine(" +");


        }
    }
}
