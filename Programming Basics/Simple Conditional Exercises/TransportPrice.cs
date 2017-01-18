using System;

namespace TransportPrice
{
    class Program
    {
        static void Main(string[] args)
        {
            var km = int.Parse(Console.ReadLine());
            var dayornight = Console.ReadLine();
            var price = 0.00;

            if (km < 20)
            {
                if (dayornight == "day")
                {
                    price = 0.7 + km * 0.79;
                    Console.WriteLine(price);
                }
                else
                {
                    price = 0.7 + km * 0.9;
                    Console.WriteLine(price);
                }
            }
            else if (km < 100)
            {
                price = 0.09 * km;
                Console.WriteLine(price);
            }
            else
            {
                price = 0.06 * km;
                Console.WriteLine(price);
            }


        }
    }
}
