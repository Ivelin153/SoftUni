namespace TargetPractice
{
    using System;
    using System.Linq;

    public class Snakes
    {
        public static void Main()
        {
            var matrixSize = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var snakeString = Console.ReadLine().ToCharArray();

            var blastParameters = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char[,] matrix = new char[matrixSize[0], matrixSize[1]];
            var currentLetter = 0;
            var directionOfRow = 1;
            for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
            {
                if (directionOfRow % 2 != 0)
                {
                    for (int column = matrix.GetLength(1) - 1; column >= 0; column--)
                    {
                        matrix[row, column] = snakeString[currentLetter];
                        currentLetter++;
                        if (currentLetter == snakeString.Length)
                        {
                            currentLetter = 0;
                        }
                    }
                }
                else
                {
                    for (int column = 0; column < matrix.GetLength(1); column++)
                    {
                        matrix[row, column] = snakeString[currentLetter];
                        currentLetter++;
                        if (currentLetter == snakeString.Length)
                        {
                            currentLetter = 0;
                        }
                    }
                }
                directionOfRow++;
            }

            var impactRow = blastParameters[0];
            var impactColumn = blastParameters[1];
            var impactRadius = blastParameters[2];
            var halfImpact = impactRadius / 2;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if ((row - impactRow) * (row - impactRow) +
                        (col - impactColumn) * (col - impactColumn) <=
                        impactRadius * impactRadius)
                    {
                        matrix[row, col] = ' ';
                    }
                }
            }

            bool fallen = false;
            do
            {
                fallen = false;
                for (int row = 0; row < matrix.GetLength(0) - 1; row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] != ' ' && matrix[row + 1, col] == ' ')
                        {
                            matrix[row + 1, col] = matrix[row, col];
                            matrix[row, col] = ' ';
                            fallen = true;
                        }
                    }
                }
            } while (fallen);

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    Console.Write(matrix[r, c]);
                }
                Console.WriteLine();
            }

        }

    }
}
