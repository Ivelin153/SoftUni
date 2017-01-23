using System;
namespace RefactorSpecialNumbers
{
    class RefactorSpecalNumbers
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());
            int sum = 0;
            int digit = 0;
            bool falseOrTrue = false;
            for (int num = 1; num <= numbers; num++)
            {
                digit = num;
                while (digit > 0)
                {
                    sum += digit % 10;
                    digit = digit / 10;
                }
                falseOrTrue = (sum == 5) || (sum == 7) || (sum == 11);
                Console.WriteLine($"{num} -> {falseOrTrue}");
                sum = 0;
            }

        }
    }
}
