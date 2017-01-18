using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxCombination
{
    class Program
    {
        static void Main(string[] args)
        {
            var intervalBegining = int.Parse(Console.ReadLine());
            var intervalEnd = int.Parse(Console.ReadLine());
            var maxCombinations = int.Parse(Console.ReadLine());
            var counter = 0;

            for (int i = intervalBegining; i <= intervalEnd; i++)
            {
                for (int j = intervalBegining; j <= intervalEnd; j++)
                {                    
                    
                    if (counter >= maxCombinations)
                    {
                        break;
                    }
                    counter++;
                    Console.Write("<{0}-{1}>", i, j);
                }
            }
        }
    }
}
