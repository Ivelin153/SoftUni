using System;
namespace NumbersInReversedOrder
{
    class Program
    {
        public static void Main(string[] args)
        {
            var numberToCheck = double.Parse(Console.ReadLine());
            ReversedNumbers(numberToCheck);
        }

        public static void ReversedNumbers(double number)
        {
            var toString = number.ToString();
            string reversed = string.Empty;

            foreach (char ch in toString)
            {
                reversed = ch + reversed;
            }
            Console.WriteLine(reversed);
        }
    }
}
