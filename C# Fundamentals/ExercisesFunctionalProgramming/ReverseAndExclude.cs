namespace ReverseAndExclude
{
    using System;
    using System.Linq;

    class ReverseAndExclude
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.None)
                .Select(int.Parse)
                .Reverse()
                .ToArray();
            var divider = int.Parse(Console.ReadLine());

            Func<int, bool> divisor = n => n % divider != 0;

            var remainingNumbers = numbers.Where(divisor);

            Console.WriteLine(string.Join(" ", remainingNumbers));
        }
    }
}
