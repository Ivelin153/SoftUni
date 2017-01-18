using System;

namespace VegetableShop
{
    class Program
    {
        static void Main(string[] args)
        {
            var vegtablePrice = double.Parse(Console.ReadLine());
            var fruitPrice = double.Parse(Console.ReadLine());
            var vegtableKG = double.Parse(Console.ReadLine());
            var fruitKG = double.Parse(Console.ReadLine());

            var vegtable = vegtablePrice * vegtableKG;
            var fruit = fruitPrice * fruitKG;
            var total = (vegtable + fruit) / 1.94;
            Console.WriteLine(total);

        }
    }
}
