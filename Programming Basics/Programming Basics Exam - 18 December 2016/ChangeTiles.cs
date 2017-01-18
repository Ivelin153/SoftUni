using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeTiles
{
    class Program
    {
        static void Main(string[] args)
        {
            var savedMoney = double.Parse(Console.ReadLine());
            var floorWidth = double.Parse(Console.ReadLine());
            var floorLength = double.Parse(Console.ReadLine());
            var triangleSide = double.Parse(Console.ReadLine());
            var triangleHeigth = double.Parse(Console.ReadLine());
            var priceForPlate = double.Parse(Console.ReadLine());
            var paymentToWorker = double.Parse(Console.ReadLine());

            var floorArea = floorLength * floorWidth;
            var plateArea = triangleSide * triangleHeigth / 2;
            var platesNeeded = Math.Ceiling(floorArea / plateArea) + 5;
            var moneyNeeded = priceForPlate * platesNeeded + paymentToWorker;

            if (savedMoney >= moneyNeeded)
            {
                Console.WriteLine("{0:f2} lv left.",
                    savedMoney - moneyNeeded);
            }
            else
            {
                Console.WriteLine("You'll need {0:f2} lv more.",
                    moneyNeeded - savedMoney);
            }
        }
    }
}
