using System;
namespace ComparingFloats
{
    class ComparingFloats
    {
        static void Main(string[] args)
        {
            var number1 = double.Parse(Console.ReadLine());
            var number2 = double.Parse(Console.ReadLine());
            var difference = Math.Abs(number1 - number2);
            var eps = 0.000001;
            if (difference >= eps)
            {
                Console.WriteLine("False");
            }
            else if (difference < eps)
            {
                Console.WriteLine("True");
            }
        }
    }
}
