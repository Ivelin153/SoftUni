using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            var budget = double.Parse(Console.ReadLine());
            var seasson = Console.ReadLine();
            var price = 0.00;


            if (budget <= 100)
            {
                Console.WriteLine("Somewhere in Bulgaria");
                if (seasson == "summer")
                {
                    price = budget * 0.3;
                    Console.WriteLine("Camp - {0:f2}", price);
                }
                else
                {
                    price = budget * 0.7;
                    Console.WriteLine("Hotel - {0:f2}", price);
                }
            }
            else if (budget <= 1000)
            {
                Console.WriteLine("Somewhere in Balkans");
                if (seasson == "summer")
                {
                    price = budget * 0.4;
                    Console.WriteLine("Camp - {0:f2}", price);
                }
                else
                {
                    price = budget * 0.8;
                    Console.WriteLine("Hotel - {0:f2}", price);
                }
            }
            else
            {
                Console.WriteLine("Somewhere in Europe");
                price = budget * 0.9;
                Console.WriteLine("Hotel - {0:f2}", price);
            }
        }
    }
}
