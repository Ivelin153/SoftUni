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
            var toString = numb.ToString();
            string reversed = string.Empty;

            foreach (char ch in toString)
            {
                reversed = ch + reversed;
            }

            var reversedNumber = Convert.ToInt32(reversed);

            if (reversedNumber == numb)
            {
                return true;
            }
            else
            {
                return false;
            }
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

            else
            {
                return false;
            }
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

            else
            {
                return false;
            }
        }
    }
}


