namespace PalindromMatrix
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var alphabet = "abcdefghijklmnopqrstuvwxyz".ToList();
            var rowsAndCols = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            string[,] matrix = new string[rowsAndCols[0], rowsAndCols[1]];

            int currentColumnLetter = 0;
            for (int rows = 0; rows < rowsAndCols[0]; rows++)
            {
                for (int cols = 0; cols < rowsAndCols[1]; cols++)
                {
                    matrix[rows, cols] = $"{alphabet[rows]}{alphabet[currentColumnLetter + cols]}{alphabet[rows]}";
                }
                currentColumnLetter++;
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    Console.Write(matrix[row,column] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
