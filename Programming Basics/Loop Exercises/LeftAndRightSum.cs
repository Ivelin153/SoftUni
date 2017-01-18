using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeftAndRightSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var leftSum = 0;
            var rightSum = 0;

            for (int i = 0; i < 2 * n; i++)
            {
                var numbers = int.Parse(Console.ReadLine());
                if (i < n)
                {
                    leftSum += numbers;
                }
                else
                {
                    rightSum += numbers;
                }
            }
            if (leftSum == rightSum)
            {
                Console.WriteLine("Yes, sum = {0}", leftSum);
            }
            else
            {
                Console.WriteLine("No, diff = {0}",
                    Math.Abs(leftSum-rightSum));
            }
        }
    }
}
