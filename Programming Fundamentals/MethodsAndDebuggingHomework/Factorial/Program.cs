using System;
using System.Numerics;
namespace Factorial
{
    public class Program
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            Factorial(number);
        }

        public static void Factorial(int n)
        {
            BigInteger factorial = 1;

            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
            }

            Console.WriteLine(factorial);
        }
    }
}
