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
            var season = Console.ReadLine();

            if (budget <= 100)
            {
                if (season == "summer")
                {
                    budget *= 0.3;
                    Console.WriteLine("Somewhere in Bulgaria");
                    Console.WriteLine("Camp - {0:f2}", budget);
                }
                else
                {
                    budget *= 0.7;
                    Console.WriteLine("Somewhere in Bulgaria");
                    Console.WriteLine("Hotel - {0:f2}", budget);
                }

            }
            else if (budget <= 1000)
            {
                if (season == "summer")
                {
                    budget *= 0.4;
                    Console.WriteLine("Somewhere in Balkans");
                    Console.WriteLine("Camp - {0:f2}", budget);
                }
                else
                {
                    budget *= 0.8;
                    Console.WriteLine("Somewhere in Balkans");
                    Console.WriteLine("Hotel - {0:f2}", budget);
                }
            }
            else
            {
                budget *= 0.9;
                Console.WriteLine("Somewhere in Europe");
                Console.WriteLine("Hotel - {0:f2}", budget);
            }

        }
    }
}
