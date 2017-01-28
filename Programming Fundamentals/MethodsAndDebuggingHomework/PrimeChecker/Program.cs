using System;
namespace PrimeChecker
{
    class Program
    {
        public static void Main()
        {
            var n = long.Parse(Console.ReadLine());
            PrimeChecker(n, true);
        }

        public static void PrimeChecker(long n, bool isPrime)
        {
            if (n < 2)
            {
                Console.WriteLine("False");
            }
            else
            {
                for (int i = 2; i <= Math.Sqrt(n); i++)
                {
                    if (n % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime == true)
                {
                    Console.WriteLine("True");
                }
                else
                {
                    Console.WriteLine("False");
                }
            }
        }
    }
}