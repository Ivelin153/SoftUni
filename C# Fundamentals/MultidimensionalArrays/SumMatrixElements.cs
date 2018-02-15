namespace SumMatrixElements
{
    using System;
    using System.Linq;

    public class SumElements
    {
        public static void Main()
        {
            var rowsAndColumns = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.None)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[rowsAndColumns[0], rowsAndColumns[1]];
            int sum = 0;

            for (int rows = 0; rows < rowsAndColumns[0]; rows++)
            {
                var rowValues = Console.ReadLine()
                    .Split(new string[] { ", " }, StringSplitOptions.None)
                    .Select(int.Parse)
                    .ToArray();

                for (int columns = 0; columns < rowsAndColumns[1]; columns++)
                {
                    matrix[rows, columns] = rowValues[columns];
                    sum += rowValues[columns];
                }
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sum);
        }
    }
}
