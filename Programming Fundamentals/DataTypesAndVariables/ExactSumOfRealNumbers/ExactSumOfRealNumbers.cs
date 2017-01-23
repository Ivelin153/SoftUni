using System;
namespace ExactSumOfRealNumbers
{
    class ExactSumOfRealNumbers
    {
        static void Main(string[] args)
        {
            var numbers = int.Parse(Console.ReadLine());
            decimal sum = 0;
            for (int i = 0; i < numbers; i++)
            {
                decimal realNum = decimal.Parse(Console.ReadLine());
                sum += realNum;
            }
            Console.WriteLine(sum);
        }
    }
}
