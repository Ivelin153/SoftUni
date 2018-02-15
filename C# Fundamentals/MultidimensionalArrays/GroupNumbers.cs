namespace GroupNumbers
{
    using System;
    using System.Linq;

    public class GroupNumbers
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.None)
                .Select(int.Parse)
                .ToArray();

            int[] sizes = new int[3];

            foreach (var number in numbers)
            {
                sizes[Math.Abs(number % 3)]++;
            }

            int[][] jaggedArray = new int[3][];
            for (int counter = 0; counter < sizes.Length; counter++)
            {
                jaggedArray[counter] = new int[sizes[counter]];
            }

            int[] index = new int[3];
            foreach (var number in numbers)
            {
                var reminder = Math.Abs(number % 3);
                jaggedArray[reminder][index[reminder]] = number;
                index[reminder]++;
            }

            for (int rows = 0; rows < jaggedArray.Length; rows++)
            {
                for (int cols = 0; cols < jaggedArray[rows].Length; cols++)
                {
                    Console.Write(jaggedArray[rows][cols] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
