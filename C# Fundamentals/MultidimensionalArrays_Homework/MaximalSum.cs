namespace MaximalSum
{
    using System;
    using System.Linq;

    public class Max3x3Squares
    {
        public static void Main()
        {
            int[] rowsAndColumns = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[rowsAndColumns[0], rowsAndColumns[1]];

            for (int rows = 0; rows < rowsAndColumns[0]; rows++)
            {
                var rowValues = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
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
            for (int rows = 0; rows < matrix.GetLength(0) - 2; rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1) - 2; cols++)
                {
                    var tempSum = 0;

                    tempSum = matrix[rows, cols] + matrix[rows, cols + 1] + matrix[rows, cols + 2] +
                            matrix[rows + 1, cols] + matrix[rows + 1, cols + 1] + matrix[rows + 1, cols + 2] +
                            matrix[rows + 2, cols] + matrix[rows + 2, cols + 1] + matrix[rows + 2, cols + 2];

                    if (tempSum > maxSum)
                    {
                        maxSum = tempSum;
                        rowIndex = rows;
                        colIndex = cols;
                    }
                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            for (int row = rowIndex; row < rowIndex + 3; row++)
            {
                for (int col = colIndex; col < colIndex + 3; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
