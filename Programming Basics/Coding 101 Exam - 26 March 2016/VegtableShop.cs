using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegtableShop
{
    class Program
    {
        static void Main(string[] args)
        {
            var vegtablePrice = double.Parse(Console.ReadLine());
            var fruitPrice = double.Parse(Console.ReadLine());
            var vegtableKG = double.Parse(Console.ReadLine());
            var fruitKG = double.Parse(Console.ReadLine());

            var price = ((vegtablePrice * vegtableKG) + (fruitPrice * fruitKG)) / 1.94;
            Console.WriteLine(price);
        }
    }
}
