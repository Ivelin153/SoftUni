using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvest
{
    class Program
    {
        static void Main(string[] args)
        {
            var vineYardArea = int.Parse(Console.ReadLine());
            var grapesPerSqM = double.Parse(Console.ReadLine());
            var wineForSale = int.Parse(Console.ReadLine());
            var numberOfWorkers = int.Parse(Console.ReadLine());

            var totalGrapes = vineYardArea * grapesPerSqM;
            var forWine = (totalGrapes * 0.4) / 2.5;

            if (forWine >= wineForSale)
            {
                Console.WriteLine("Good harvest this year! Total wine: {0} liters.",
                    Math.Floor(forWine));
                Console.WriteLine("{0} liters left -> {1} liters per person.",
                    Math.Ceiling(forWine - wineForSale),
                    Math.Ceiling((forWine - wineForSale) / numberOfWorkers));
            }
            else
            {
                Console.WriteLine("It will be a tough winter! More {0} liters wine needed.",
                    Math.Floor(wineForSale - forWine));

            }
        }
    }
}
