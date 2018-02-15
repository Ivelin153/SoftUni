namespace DiagonalDifference
{
    using System;
    using System.Linq;

    public class DiagonalDiff
    {
        public static void Main()
        {
            int matrixSize = int.Parse(Console.ReadLine());

            long[,] square = new long[matrixSize, matrixSize];


            for (int rows = 0; rows < square.GetLength(0); rows++)
            {
                var numbers = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToArray();

                for (int columns = 0; columns < square.GetLength(0); columns++)
                {
                    square[rows, columns] = numbers[columns];
                }
            }

            long primaryDiagonal = 0;

            for (int rows = 0; rows < square.GetLength(0); rows++)
            {
                primaryDiagonal += square[rows, rows];
            }

            long secondaryDiagonal = 0;
            for (int row = 0, col = matrixSize - 1; row < matrixSize; row++, col--)
            {
                secondaryDiagonal += square[row,col];
            }

            Console.WriteLine(Math.Abs(primaryDiagonal - secondaryDiagonal));
        }
    }
}