namespace BasicStackOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(' ');

            var elementsToPush = int.Parse(input[0]);
            var elementsToPop = int.Parse(input[1]);
            var elementToFind = int.Parse(input[2]);
            
            var stack = new Stack<int>();
            var elements = Console.ReadLine().Split(' ');
            for (int i = 0; i < elementsToPush; i++)
            {
                var currentElement = int.Parse(elements[i]);
                stack.Push(currentElement);
            }

            for (int i = 0; i < elementsToPop; i++)
            {
                stack.Pop();
            }

            if (stack.Contains(elementToFind))
            {
                Console.WriteLine("true");
            }
            else if (stack.Count==0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
            
        }
    }
}
