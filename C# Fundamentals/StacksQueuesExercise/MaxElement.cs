namespace MaxElement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class MaxElement
    {
        public static void Main()
        {
            var numberOfQuearies = int.Parse(Console.ReadLine());

            var stack = new Stack<int>();
            var maxElement = new Stack<int>();
            maxElement.Push(0);

            for (int i = 0; i < numberOfQuearies; i++)
            {
                var input = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                var queary = input[0];
                if (queary == 1)
                {
                    var number = input[1];
                    stack.Push(number);

                    if (stack.Peek() > maxElement.Peek())
                    {
                        maxElement.Push(number);
                    }
                }
                else if (queary == 2)
                {
                    if (maxElement.Contains(stack.Peek()))
                    {
                        maxElement.Pop();
                    }
                    
                    stack.Pop();
                }
                if (queary == 3)
                {
                    Console.WriteLine(maxElement.Peek());
                }
            }

        }
    }
}
