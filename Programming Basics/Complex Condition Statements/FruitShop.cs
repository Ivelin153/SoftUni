using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitShop
{
    class Program
    {
        static void Main(string[] args)
        {
            var fruit = Console.ReadLine().ToLower();
            var day = Console.ReadLine().ToLower();
            var quintanity = double.Parse(Console.ReadLine());
            var price = 0.00;

            if (day == "monday" || day == "tuesday" || day == "wednesday" || day == "thursday" || day == "friday")
            {
                if (fruit == "banana")
                {
                    price = 2.5 * quintanity;
                    Console.WriteLine(price);
                }
                else if (fruit == "apple")
                {
                    price = 1.2 * quintanity;
                    Console.WriteLine(price);
                }
                else if (fruit == "orange")
                {
                    price = 0.85 * quintanity;
                    Console.WriteLine(price);
                }
                else if (fruit == "grapefruit")
                {
                    price = 1.45 * quintanity;
                    Console.WriteLine(price);
                }
                else if (fruit == "kiwi")
                {
                    price = 2.7 * quintanity;
                    Console.WriteLine(price);
                }
                else if (fruit == "pineapple")
                {
                    price = 5.5 * quintanity;
                    Console.WriteLine(price);
                }
                else if (fruit == "grapes")
                {
                    price = 3.85 * quintanity;
                    Console.WriteLine(price);
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (day == "sunday" || day == "saturday")
            {
                if (fruit == "banana")
                {
                    price = 2.7 * quintanity;
                    Console.WriteLine(price);
                }
                else if (fruit == "apple")
                {
                    price = 1.25 * quintanity;
                    Console.WriteLine(price);
                }
                else if (fruit == "orange")
                {
                    price = 0.9 * quintanity;
                    Console.WriteLine(price);
                }
                else if (fruit == "grapefruit")
                {
                    price = 1.6 * quintanity;
                    Console.WriteLine(price);
                }
                else if (fruit == "kiwi")
                {
                    price = 3 * quintanity;
                    Console.WriteLine(price);
                }
                else if (fruit == "pineapple")
                {
                    price = 5.6 * quintanity;
                    Console.WriteLine(price);
                }
                else if (fruit == "grapes")
                {
                    price = 4.2 * quintanity;
                    Console.WriteLine(price);
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}

