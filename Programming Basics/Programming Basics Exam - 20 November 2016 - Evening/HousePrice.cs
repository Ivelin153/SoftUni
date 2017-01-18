using System;
namespace HousePrice
{
    class Program
    {
        static void Main(string[] args)
        {
            var smallestRoom = double.Parse(Console.ReadLine());
            var kitchen = double.Parse(Console.ReadLine());
            var priceForSqM = double.Parse(Console.ReadLine());

            var bathroom = smallestRoom / 2;
            var secondRoom = smallestRoom + (0.1 * smallestRoom);
            var thirdRoom = secondRoom + (0.1 * secondRoom);
            var totalArea = (smallestRoom + kitchen + bathroom + secondRoom + thirdRoom) * 1.05;
            var totalPrice = totalArea * priceForSqM;
            Console.WriteLine("{0:f2}", totalPrice);

        }
    }
}
