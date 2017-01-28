using System;
namespace Fibonacci
{
    class Program
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            Fibonacci(n);
        }

        public static void Fibonacci(int n)
        {            
            var f0 = 1;
            var f1 = 1;
            var fNext = 0;

            for (int i = 0; i < n - 1; i++)
            {
                fNext = f0 + f1;
                f0 = f1;
                f1 = fNext;
            }
            Console.WriteLine(f1);
        }
    }
}
