using System;
namespace SpecialNumbers
{
    class SpecialNumbers
    {
        static void Main(string[] args)
        {
            var numbers = int.Parse(Console.ReadLine());
            for (int n = 1; n <= numbers; n++)
            {
                var sum = 0;
                var digit = n;
                while (digit > 0)
                {
                    sum += digit % 10;
                    digit = digit / 10;
                }
                if (sum == 5 || sum == 7 || sum == 11)
                {
                    Console.WriteLine("{0} -> True", n);
                }
                else
                {
                    Console.WriteLine("{0} -> False", n);
                }
            }
        }
    }
}
