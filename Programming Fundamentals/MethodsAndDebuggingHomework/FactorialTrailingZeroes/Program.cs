using System;
using System.Numerics;
namespace FactorialTrailingZeroes
{
    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            BigInteger factorialResult = Factorial(n);
            TrailingZeroes(factorialResult);
        }

        public static BigInteger Factorial(int n)
        {
            BigInteger factorial = 1;

            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
            }

            return factorial;
        }

        public static void TrailingZeroes(BigInteger factorial)
        {
            var counter = 0;
            BigInteger digit = 0;
            var number = factorial;
            while (digit == 0)
            {
                digit = number % 10;
                number /= 10;
                if (digit == 0)
                {
                    counter++;
                }
                
            }
            Console.WriteLine(counter);
        }
    }
}
