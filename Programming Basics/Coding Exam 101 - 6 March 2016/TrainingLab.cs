using System;


namespace Training_Lab
{
    class Program
    {
        static void Main(string[] args)
        {

            var width = double.Parse(Console.ReadLine());
            var length = double.Parse(Console.ReadLine());

            var corridor = 1;
            var tableWidth = 1.2;
            var tableLength = 0.7;

            var lengthWithoutCorridor = length - corridor;
            var numberOfTablesInRow = Math.Floor(lengthWithoutCorridor / tableLength);

            var numberOfRows = Math.Floor(width / tableWidth);
            

            Console.WriteLine(numberOfTablesInRow*numberOfRows-3);

        }
    }
}
