using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipesInPool
{
    class Program
    {
        static void Main(string[] args)
        {
            var v = int.Parse(Console.ReadLine());
            var p1 = int.Parse(Console.ReadLine());
            var p2 = int.Parse(Console.ReadLine());
            var h = double.Parse(Console.ReadLine());

            var pipe1 = p1 * h;
            var pipe2 = p2 * h;
            var poolFilled = pipe1 + pipe2;
            var poolPercent = (poolFilled / v) * 100;
            var pipe1Percent = pipe1 / poolFilled * 100;
            var pipe2Percent = pipe2 / poolFilled * 100;

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
