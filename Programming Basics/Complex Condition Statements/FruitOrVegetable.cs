﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitOrVegetable
{
    class Program
    {
        static void Main(string[] args)
        {
            var name = Console.ReadLine().ToLower();

            if (name == "banana" || name == "kiwi" || name == "apple" || name == "cherry" || name == "lemon" || name == "grapes")
            {
                Console.WriteLine("fruit");
            }
            else if (name == "tomato" || name == "cucumber" || name == "pepper" || name == "carrot")
            {
                Console.WriteLine("vegetable");
            }
            else
            {
                Console.WriteLine("unknown");
            }
        }
    }
}
