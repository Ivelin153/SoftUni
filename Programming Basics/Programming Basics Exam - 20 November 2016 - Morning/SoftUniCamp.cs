using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniCamp
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var car = 0.00;
            var minibus = 0.00;
            var autobus = 0.00;
            var bigAutobus = 0.00;
            var train = 0.00;
            var totalNumber = 0.00;

            for (int i = 0; i < n; i++)
            {
                var numberOfPeople = int.Parse(Console.ReadLine());
                if (numberOfPeople <= 5)
                {
                    car += numberOfPeople;
                }
                else if (numberOfPeople <= 12)
                {
                    minibus += numberOfPeople;
                }
                else if (numberOfPeople <= 25)
                {
                    autobus += numberOfPeople;
                }
                else if (numberOfPeople <= 40)
                {
                    bigAutobus += numberOfPeople;
                }
                else
                {
                    train += numberOfPeople;
                }
                totalNumber += numberOfPeople;
            }
            Console.WriteLine("{0:f2}%", car / totalNumber * 100);
            Console.WriteLine("{0:f2}%", minibus / totalNumber * 100);
            Console.WriteLine("{0:f2}%", autobus / totalNumber * 100);
            Console.WriteLine("{0:f2}%", bigAutobus / totalNumber * 100);
            Console.WriteLine("{0:f2}%", train / totalNumber * 100);
        }
    }
}
