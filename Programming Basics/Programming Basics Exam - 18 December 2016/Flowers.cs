using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flowers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfChrysanthemum = int.Parse(Console.ReadLine());
            var numberOfRoses = int.Parse(Console.ReadLine());
            var numberOfTulips = int.Parse(Console.ReadLine());
            var season = Console.ReadLine();
            var holiday = Console.ReadLine();
            var priceForFlowers = 0.00;

            var priceOfChrysanthemum = 2.00;
            var priceOfRoses = 4.10;
            var priceOfTulips = 2.50;

            var numberOfFlowers = numberOfChrysanthemum + numberOfRoses + numberOfTulips;

            if (season == "Spring" || season == "Summer")
            {
                priceForFlowers = numberOfChrysanthemum * priceOfChrysanthemum + numberOfRoses * priceOfRoses + numberOfTulips * priceOfTulips;
                if (holiday == "Y")
                {
                    Math.Round(priceForFlowers *= 1.15, 2);
                }
                if (numberOfTulips > 7 && season == "Spring")
                {
                    priceForFlowers = priceForFlowers - (priceForFlowers * 0.05);
                }
                if (numberOfFlowers > 20)
                {
                    priceForFlowers = priceForFlowers - (priceForFlowers * 0.2);
                }
                Console.WriteLine("{0:f2}", priceForFlowers + 2);
            }
            else
            {
                priceOfChrysanthemum = 3.75;
                priceOfRoses = 4.50;
                priceOfTulips = 4.15;
                priceForFlowers = numberOfChrysanthemum * priceOfChrysanthemum + numberOfRoses * priceOfRoses + numberOfTulips * priceOfTulips;
                if (holiday == "Y")
                {
                    Math.Round(priceForFlowers *= 1.15, 2);
                }
                if (numberOfRoses >= 10 && season == "Winter")
                {
                    priceForFlowers = priceForFlowers - (priceForFlowers * 0.1);
                }
                if (numberOfFlowers > 20)
                {
                    priceForFlowers = priceForFlowers - (priceForFlowers * 0.2);
                }
                Console.WriteLine("{0:f2}", priceForFlowers + 2);
            }



        }
    }
}
