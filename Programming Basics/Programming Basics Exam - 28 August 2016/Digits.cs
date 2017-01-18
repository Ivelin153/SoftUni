using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());

            var numCopy = number;
            var digit3 = numCopy % 10;
            numCopy /= 10;
            var digit2 = numCopy % 10;
            numCopy /= 10;
            var digit1 = numCopy % 10;

            for (int i = 1; i <= digit1 + digit2; i++)
            {
                for (int j = 1; j <= digit1 + digit3; j++)
                {
                    if (number % 5 == 0)
                    {
                        number -= digit1;
                    }
                    else if (number % 3 == 0)
                    {
                        number -= digit2;
                    }
                    else
                    {
                        number += digit3;
                    }
                    Console.Write("{0} ", number);
                }
                Console.WriteLine();
            }
        }
    }
}
