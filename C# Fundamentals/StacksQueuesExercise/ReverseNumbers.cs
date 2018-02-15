namespace ReverseNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ReverseNumbs
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var stack = new Stack<int>();

            for (int i = 0; i < input.Count(); i++)
            {
                stack.Push(input[i]);
            }
            var stackCount = stack.Count;

            Console.WriteLine(string.Join(" ", stack));


        }
    }
}
