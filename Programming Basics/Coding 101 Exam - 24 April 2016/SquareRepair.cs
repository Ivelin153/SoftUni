using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareRepair
{
    class Program
    {
        static void Main(string[] args)
        {
            var squareSide = int.Parse(Console.ReadLine());
            var plateWidth = double.Parse(Console.ReadLine());
            var plateLength = double.Parse(Console.ReadLine());
            var benchWidth = int.Parse(Console.ReadLine());
            var benchLength = int.Parse(Console.ReadLine());

            var squareArea = squareSide * squareSide;
            var benchArea = benchLength * benchWidth;
            var plateArea = plateWidth * plateLength;
            var plateNumber = (squareArea - benchArea) / plateArea;
            var timeForRepair = plateNumber * 0.2;
            
            Console.WriteLine(plateNumber);
            Console.WriteLine(timeForRepair);
        }
    }
}
