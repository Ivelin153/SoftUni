using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingLab
{
    class Program
    {
        static void Main(string[] args)
        {
            var length = double.Parse(Console.ReadLine());
            var width = double.Parse(Console.ReadLine());
            var tableWidth = 0.7;
            var tableLength = 1.2;
            var hallWithoutCorridor = width - 1;

            var numberOfRows = Math.Floor(length / tableLength);
            var tablesInRows = Math.Floor(hallWithoutCorridor / tableWidth);           
            var numberOfTables = (numberOfRows * tablesInRows) - 3;
            Console.WriteLine(numberOfTables);



        }
    }
}
