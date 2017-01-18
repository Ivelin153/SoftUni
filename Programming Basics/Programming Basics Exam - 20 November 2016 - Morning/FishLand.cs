using System;
namespace Fishland
{
    class Program
    {
        static void Main(string[] args)
        {
            var mackerelPrice = double.Parse(Console.ReadLine());
            var spratPrice = double.Parse(Console.ReadLine());
            var palamudKG = double.Parse(Console.ReadLine());
            var safridKG = double.Parse(Console.ReadLine());
            var clamsKG = int.Parse(Console.ReadLine());

            var palamudPrice = mackerelPrice * 1.6;
            var palamudTotal = palamudPrice * palamudKG;
            var safridPrice = spratPrice * 1.8;
            var safridTotal = safridKG * safridPrice;
            var clamsTotal = clamsKG * 7.5;
            var total = palamudTotal + safridTotal + clamsTotal;
            Console.WriteLine("{0}", total);
        }
    }
}
