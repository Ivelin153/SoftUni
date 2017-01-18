using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport_Price
{
    class Program
    {
        static void Main(string[] args)
        {

            var km = int.Parse(Console.ReadLine());
            var dayOrNight = Console.ReadLine();

            if (km < 20)
            {
                if (dayOrNight == "day")
                {
                    var price = 0.7 + km * 0.79;
                    Console.WriteLine(price);
                }
                else
                {
                    var price = 0.7 + km * 0.9;
                    Console.WriteLine(price);
                }
            }

            if (km >= 20)
            {
                var price = km * 0.09;
                Console.WriteLine(price);
            }

            if (km >= 100)
            {
                var price = km * 0.06;
                Console.WriteLine(price);
            }

        }
    }
}
