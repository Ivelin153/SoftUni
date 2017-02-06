using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var input = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToList();

        var numbAndPow = Console.ReadLine().Split(' ');

        int number = int.Parse(numbAndPow[0]);
        int power = int.Parse(numbAndPow[1]);

        for (int i = 0; i < input.Count; i++)
        {
            if (input[i] == number)
            {
                int left = Math.Max(i - power, 0);

                int right = Math.Min(i + power, input.Count - 1);

                int lenght = right - left + 1;
                input.RemoveRange(left, lenght);
                i = 0;
            }
        }
        Console.WriteLine(input.Sum());
    }
}