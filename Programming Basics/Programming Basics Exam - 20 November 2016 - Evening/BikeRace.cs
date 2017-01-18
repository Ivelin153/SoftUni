using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRace
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfYoungRiders = int.Parse(Console.ReadLine());
            var numberOfOldRiders = int.Parse(Console.ReadLine());
            var trace = Console.ReadLine();
            var yTax = 0.00;
            var oTax = 0.00;
            var sum = 0.00;
            var charity = 0.00;

            if (trace == "trail")
            {
                sum = numberOfYoungRiders * 5.5 + numberOfOldRiders * 7;
                charity = sum - sum * 0.05;
                Console.WriteLine("{0:f2}", charity);
            }
            else if (trace == "cross-country")
            {
                var totalParticipants = numberOfYoungRiders + numberOfOldRiders;
                if (totalParticipants >= 50)
                {
                    yTax = 8 - 8 * 0.25;
                    oTax = 9.5 - 9.5 * 0.25;
                    sum = numberOfYoungRiders * yTax + numberOfOldRiders * oTax;
                    charity = sum - sum * 0.05;
                    Console.WriteLine("{0:f2}", charity);
                }
                else
                {
                    yTax = 8;
                    oTax = 9.5;
                    sum = numberOfYoungRiders * yTax + numberOfOldRiders * oTax;
                    charity = sum - sum * 0.05;
                    Console.WriteLine("{0:f2}", charity);
                }
            }
            else if (trace == "downhill")
            {
                sum = numberOfYoungRiders * 12.25 + numberOfOldRiders * 13.75;
                charity = sum - sum * 0.05;
                Console.WriteLine("{0:f2}", charity);
            }
            else
            {
                sum = numberOfYoungRiders * 20 + numberOfOldRiders * 21.5;
                charity = sum - sum * 0.05;
                Console.WriteLine("{0:f2}", charity);
            }
        }
    }
}
