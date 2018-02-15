namespace SquaresInMatrix
{
    using System;
    using System.Linq;

    public class SquaresInMatrix
    {
        public static void Main()
        {
            var rowsAndCols = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char[,] matrix = new char[rowsAndCols[0], rowsAndCols[1]];

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                var characters = Console.ReadLine()
                   .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                   .Select(char.Parse)
                   .ToArray();

                for (int columns = 0; columns < matrix.GetLength(1); columns++)
                {
                    matrix[rows, columns] = characters[columns];
                }
            }

            var squareMatrices = 0;
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1] && matrix[row, col] == matrix[row + 1, col] && matrix[row, col] == matrix[row + 1, col + 1])
                    {
                        squareMatrices++;
                    }
                }
            }
            Console.WriteLine(squareMatrices);
        }
    }
}
