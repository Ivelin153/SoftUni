using System;

namespace PlateRepair
{
    class Program
    {
        static void Main(string[] args)
        {
            var widthOfLanding = double.Parse(Console.ReadLine());
            var plateWidth = double.Parse(Console.ReadLine());
            var plateLength = double.Parse(Console.ReadLine());
            var benchWidth = double.Parse(Console.ReadLine());
            var benchLength = double.Parse(Console.ReadLine());

            var landingArea = widthOfLanding * widthOfLanding;
            var benchArea = benchLength * benchWidth;
            var plateArea = plateWidth * plateLength;
            var numberOfPlates = (landingArea - benchArea) / plateArea;
            var time = numberOfPlates * 0.2;
            Console.WriteLine(numberOfPlates);
            Console.WriteLine(time);


        }
    }
}
