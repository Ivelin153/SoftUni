namespace SquareWithMaxSum
{
    using System;
    using System.Linq;

    public class MaxSquare
    {
        private static int i;

        public static void Main()
        {
            int[] rowsAndColumns = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.None)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[rowsAndColumns[0], rowsAndColumns[1]];

            for (int rows = 0; rows < rowsAndColumns[0]; rows++)
            {
                var rowValues = Console.ReadLine()
                    .Split(new string[] { ", " }, StringSplitOptions.None)
                    .Select(int.Parse)
                    .ToArray();

                for (int columns = 0; columns < rowsAndColumns[1]; columns++)
                {
                    matrix[rows, columns] = rowValues[columns];
                }
            }

            var maxSum = 0;
            var rowIndex = 0;
            var colIndex = 0;
            for (int rows = 0; rows < matrix.GetLength(0) - 1; rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1) - 1; cols++)
                {
                    var tempSum = 0;
                    
                    tempSum = matrix[rows, cols] + matrix[rows, cols + 1] + matrix[rows + 1, cols] + matrix[rows + 1, cols + 1];

                    if (tempSum > maxSum)
                    {
                        maxSum = tempSum;
                        rowIndex = rows;
                        colIndex = cols;
                    }
                }
            }

            Console.WriteLine($@"{matrix[rowIndex,colIndex]} {matrix[rowIndex,colIndex+1]}
{matrix[rowIndex+1,colIndex]} {matrix[rowIndex+1,colIndex+1]}");

            Console.WriteLine(maxSum);


        }
    }
}
