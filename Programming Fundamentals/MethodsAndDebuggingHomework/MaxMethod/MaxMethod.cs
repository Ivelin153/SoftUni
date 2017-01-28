using System;
namespace MaxMethod
{
    public class MaxMethod
    {
        public static void Main()
        {
            var firstNumber = int.Parse(Console.ReadLine());
            var secondNumber = int.Parse(Console.ReadLine());
            var thirdNumber = int.Parse(Console.ReadLine());

            var result = GetMax(firstNumber, secondNumber);
            var finalComparison = GetMax(result, thirdNumber);
            Console.WriteLine(finalComparison);
        }

        public static int GetMax(int firstNumber, int secondNumber)
        {
            var biggerNumber = Math.Max(firstNumber, secondNumber);
            return biggerNumber;
        }
    }
}
