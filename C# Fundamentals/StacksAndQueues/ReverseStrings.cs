namespace ReverseStrings
{
    using System;
    using System.Collections.Generic;

    public class ReverseString
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var stack = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                stack.Push(input[i]);
            }

            foreach (var element in stack)
            {
                Console.Write(element);
            }
        }
    }
}
