using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battles
{
    class Program
    {
        static void Main(string[] args)
        {
            var pokemonsFirstPlayer = int.Parse(Console.ReadLine());
            var pokemonsSecondPlayer = int.Parse(Console.ReadLine());
            var maxBattles = int.Parse(Console.ReadLine());
            var counter = 0;

            for (int i = 1; i <= pokemonsFirstPlayer; i++)
            {
                for (int j = 1; j <= pokemonsSecondPlayer; j++)
                {
                    if (counter >= maxBattles)
                    {
                        break;
                    }
                    Console.Write("({0} <-> {1}) ",
                        i,
                        j);
                    counter++;                    
                }
            }

        }
    }
}
