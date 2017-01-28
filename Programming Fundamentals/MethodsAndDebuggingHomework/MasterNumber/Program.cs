using System;
namespace MasterNumber
{
    public class Program
    {
        public static void Main()
        {

            var numbers = int.Parse(Console.ReadLine());
            for (int i = 1; i <= numbers; i++)
            {
                if (FindSymetricNumbers(i) && SumOfDigits(i) && EvenDigit(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        public static bool FindSymetricNumbers(int numb)
        {
            int temp, remainder, reversed = 0;
            temp = numb;

            while (numb > 0)
            {
                remainder = numb % 10;
                reversed = reversed * 10 + remainder;
                numb /= 10;

            }

            if (temp == reversed)
            {
                return true;
            }

            return false;

        }

        public static bool SumOfDigits(int numb)
        {
            var sum = 0;
            var number = numb;
            while (number != 0)
            {
                sum += number % 10;
                number /= 10;
            }

            if (sum % 7 == 0)
            {
                return true;
            }
            return false;

        }

        public static bool EvenDigit(int numb)
        {
            var counter = 0;
            var digit = 0;
            var number = numb;
            while (number > 0)
            {
                digit = number % 10;
                number /= 10;
                if (digit % 2 == 0)
                {
                    counter++;
                }
            }

            if (counter > 0)
            {
                return true;
            }

            return false;
        }
    }
}



