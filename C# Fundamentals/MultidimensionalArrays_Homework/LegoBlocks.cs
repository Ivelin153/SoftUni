namespace LegoBlocks
{
    using System;
    using System.Linq;

    public class LEGO
    {
        public static void Main()
        {
            var numberOfRows = int.Parse(Console.ReadLine());

            var firstArray = new int[numberOfRows][];
            var secondArray = new int[numberOfRows][];

            for (int firstArrayLines = 0; firstArrayLines < numberOfRows; firstArrayLines++)
            {
                var arraysElements = Console.ReadLine()
                    .Trim()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                firstArray[firstArrayLines] = arraysElements;
            }

            for (int secondArrayLines = 0; secondArrayLines < numberOfRows; secondArrayLines++)
            {
                var arraysElements = Console.ReadLine()
                   .Trim()
                   .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)
                   .ToArray();

                secondArray[secondArrayLines] = arraysElements;
            }

            var reversedArray = new int[numberOfRows][];
            for (int row = 0; row < numberOfRows; row++)
            {
                var index = 0;
                var reversedRow = new int[secondArray[row].Length];
                for (int array = secondArray[row].Length - 1; array >= 0; array--)
                {
                    reversedRow[index] = secondArray[row][array];
                    index++;
                }
                reversedArray[row] = reversedRow;
            }
            var rowsWithSameLength = false;
            for (int rowsCount = 0; rowsCount < firstArray.Length - 1; rowsCount++)
            {
                if (firstArray[rowsCount].Length + reversedArray[rowsCount].Length == firstArray[rowsCount + 1].Length + reversedArray[rowsCount + 1].Length)
                {
                    rowsWithSameLength = true;
                }
                else
                {
                    rowsWithSameLength = false;
                }
            }
            if (rowsWithSameLength)
            {
                for (int currRow = 0; currRow < numberOfRows; currRow++)
                {
                    Console.Write("[");
                    Console.Write(String.Join(", ", firstArray[currRow]));
                    Console.Write(", ");
                    Console.Write(String.Join(", ",reversedArray[currRow]));
                    Console.Write("]");
                    Console.WriteLine();

                }
            }
            else
            {
                var totalCells = 0;
                for (int currRow = 0; currRow < numberOfRows; currRow++)
                {
                    foreach (var number in firstArray[currRow])
                    {
                        totalCells++;
                    }
                    foreach (var number in reversedArray[currRow])
                    {
                        totalCells++;
                    }

                }

                Console.WriteLine($"The total number of cells is: {totalCells}");
            }

        }
    }
}
