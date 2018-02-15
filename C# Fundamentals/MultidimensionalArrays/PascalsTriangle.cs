namespace PascalsTriangle
{
    using System;
    public class Program
    {
        public static void Main()
        {
            var height = int.Parse(Console.ReadLine());
            long[][] triangle = new long[height][];

            for (int currentHeight = 0; currentHeight < height; currentHeight++)
            {
                triangle[currentHeight] = new long[currentHeight + 1];
                triangle[currentHeight][0] = 1;
                triangle[currentHeight][currentHeight] = 1;

                if (currentHeight >= 2)
                {
                    for (int widhtCounter = 1; widhtCounter < currentHeight; widhtCounter++)
                    {
                        triangle[currentHeight][widhtCounter] =
                            triangle[currentHeight - 1][widhtCounter - 1] +
                            triangle[currentHeight - 1][widhtCounter];
                    }

                }
            }
            for (int rows = 0; rows < triangle.Length; rows++)
            {
                for (int columns = 0; columns < triangle[rows].Length; columns++)
                {
                    Console.Write(triangle[rows][columns] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
