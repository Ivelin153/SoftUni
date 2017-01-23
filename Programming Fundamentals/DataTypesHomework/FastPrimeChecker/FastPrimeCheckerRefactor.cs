using System;
namespace FastPrimeCheckerRefactor
{
    class FastPrimeCheckerRefactor
    {
        static void Main(string[] args)
        {
            int range = int.Parse(Console.ReadLine());
            for (int number = 2; number <= range; number++)
            {
                bool isIt = true;
                for (int modulus = 2; modulus <= Math.Sqrt(number); modulus++)
                {
                    if (number % modulus == 0)
                    {
                        isIt = false;
                        break;
                    }
                }
                Console.WriteLine($"{number} -> {isIt}");
            }

        }
    }
}
