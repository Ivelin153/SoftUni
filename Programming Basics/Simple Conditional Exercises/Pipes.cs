using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipes
{
    class Program
    {
        static void Main(string[] args)
        {
            var v = int.Parse(Console.ReadLine());
            var pipe1 = int.Parse(Console.ReadLine());
            var pipe2 = int.Parse(Console.ReadLine());
            var h = double.Parse(Console.ReadLine());

            var pipe1Filled = pipe1 * h;
            var pipe2Filled = pipe2 * h;
            var poolFilled = pipe1Filled + pipe2Filled;
            var poolPercent = poolFilled / v * 100;
            var pipe1Percent = pipe1Filled / poolFilled * 100;
            var pipe2Percent = pipe2Filled / poolFilled * 100;

            if (poolFilled <= v)
            {
                Console.WriteLine("The pool is {0}% full. Pipe 1: {1}%. Pipe 2: {2}%.",
                    Math.Floor(poolPercent),
                    Math.Floor(pipe1Percent),
                    Math.Floor(pipe2Percent));
            }
            else
            {
                Console.WriteLine("For {0} hours the pool overflows with {1} liters.",
                    h,
                    poolFilled - v);
            }
        }
    }
}
